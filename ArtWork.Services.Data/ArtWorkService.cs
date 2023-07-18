

namespace ArtStroke.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using Interfaces;
    using Web.ViewModels.Home;
    using ArtStroke.Web.ViewModels.ArtWork;
    using ArtStroke.Data.Models;
    using ArtStroke.Data;
    using ArtStroke.Services.Data.Models.ArtWork;
    using ArtStroke.Web.ViewModels.ArtWork.Enums;
    using ArtStroke.Web.ViewModels.Artist;
    using System.Globalization;

    public class ArtWorkService : IArtWorkService
    {
        private readonly ArtStrokeDbContext dbContext;
        public ArtWorkService(ArtStrokeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ArtworkAllViewModel>> AllArtworksByArtistIdAsync(string artistId)
        {
            IEnumerable<ArtworkAllViewModel> allArtworksByArtist = await this.dbContext
                .ArtWorks
                .Where(a => a.IsActive)
                .Where(a => a.ArtistId.ToString() == artistId)
                .Select(a => new ArtworkAllViewModel()
                {
                    Id = a.Id.ToString(),
                    ImageUrl = a.ImageUrl,
                    IsDesignedInPrint = a.IsDesignedInPrint,
                    Style = a.Style.Name,
                    Title = a.Title,
                }).ToArrayAsync();

            return allArtworksByArtist;
        }

        public async Task<AllArtworksFilteredServiceModel> AllAsync(AllArtworksQueryModel queryModel)
        {
            IQueryable<ArtWork> artworksQuery = this.dbContext
                 .ArtWorks
                 .AsQueryable();

            int artworksQueryCount = artworksQuery.Count();

            if (!string.IsNullOrWhiteSpace(queryModel.Style))
            {
                artworksQuery = artworksQuery
                    .Where(a => a.Style.Name == queryModel.Style);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchTerm))
            {
                string wildCard = $"%{queryModel.SearchTerm.ToLower()}%";

                artworksQuery = artworksQuery
                    .Where(a => EF.Functions.Like(a.Title, wildCard) ||
                                EF.Functions.Like(a.Technique, wildCard) ||
                                EF.Functions.Like(a.Artist.Name, wildCard));
            }

            artworksQuery = queryModel.WorksSorting switch
            {

                ArtWorkSorting.Newest => artworksQuery
                .OrderByDescending(a => a.CreatedOn),
                ArtWorkSorting.Oldest => artworksQuery
                .OrderBy(a => a.CreatedOn),
                ArtWorkSorting.CreatingYearAscending => artworksQuery
                .OrderBy(a => a.CreatingYear),
                ArtWorkSorting.CreatingYearDescending => artworksQuery
                .OrderByDescending(a => a.CreatingYear),
                _ => artworksQuery
                 .OrderBy(a => a.IsDesignedInPrint == false)
                 .ThenByDescending(a => a.CreatedOn)
            };


            IEnumerable<ArtworkAllViewModel> allArtworks = await artworksQuery
                .Where(a => a.IsActive)
                .Skip((queryModel.CurrentPage - 1) * queryModel.ArtworksPerPage)
                .Take(queryModel.ArtworksPerPage)
                .Select(a => new ArtworkAllViewModel
                {
                    Id = a.Id.ToString(),
                    Title = a.Title,
                    ImageUrl = a.ImageUrl,
                    Style = a.Style.Name,
                    IsDesignedInPrint = a.IsDesignedInPrint,
                })
                .ToArrayAsync();

            int totalArtworks = artworksQuery.Count();

            return new AllArtworksFilteredServiceModel()
            {
                CountTotalArtworks = totalArtworks,
                Artworks = allArtworks
            };
        }

        public async Task<string> CreateArtworkAsync(string artistId, ArtWorkFormModel model)
        {
            int year = model.CreatingYear;
            DateTime date = new DateTime(year, 1, 1);

            ArtWork artwork = new ArtWork()
            {
                Title = model.Title,
                Height = model.Height,
                Width = model.Width,
                CreatingYear = date,
                ArtistId = Guid.Parse(artistId),
                ImageUrl = model.ImageUrl,
                StyleId = model.StyleId,
                Technique = model.Technique,
            };

            await this.dbContext.ArtWorks.AddAsync(artwork);
            await this.dbContext.SaveChangesAsync();

            return artwork.Id.ToString();

        }

        public async Task<ArtworkDetailsViewModel> DetailsByArtistIdAsync(string artworkId)
        {
            ArtWork? artWork = await this.dbContext
                .ArtWorks
                .Include(h => h.Style)
                .Include(h => h.Artist)
                .Where(a => a.IsActive)
                .FirstAsync(a => a.Id.ToString() == artworkId);

            return new ArtworkDetailsViewModel()
            {
                Id = artWork.Id.ToString(),
                Height = artWork.Height,
                Width = artWork.Width,
                Style = artWork.Style.Name,
                ImageUrl = artWork.ImageUrl,
                IsDesignedInPrint = true,
                Title = artWork.Title,
                Technique = artWork.Technique,
                CreatingYear = artWork.CreatingYear.Year.ToString(),
                Artist = new ArtistInfoOnArtworkViewModel
                {
                    Biography = artWork.Artist.Biography,
                    Name = artWork.Artist.Name,
                }
            };
        }

        public async Task EditArtworkBtIdInFormModel(string artworkId, ArtWorkFormModel model)
        {
            ArtWork artwork = await this.dbContext
                .ArtWorks
                .Where(a => a.IsActive)
                .FirstAsync(a => a.Id.ToString() == artworkId);

            artwork.Title = model.Title;
            artwork.Technique = model.Technique;
            artwork.Width = model.Width;
            artwork.Height = model.Height;
            artwork.ImageUrl= model.ImageUrl;   
                    
            if (DateTime.TryParseExact(model.CreatingYear.ToString(), "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime creatingYear))
            {
                artwork.CreatingYear = creatingYear;
            }
            else
            {    
                artwork.CreatingYear = DateTime.MinValue;
            }

            artwork.IsDesignedInPrint = model.IsDesignedInPrint;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistByIdAsync(string artworkId)
        {
            bool result = await this.dbContext
                .ArtWorks
                .Where(a => a.IsActive)
                .AnyAsync(a => a.Id.ToString() == artworkId);

            return result;
        }

        public async Task<ArtWorkFormModel> GetArtworkForEditByIdAsync(string artworkId)
        {
            ArtWork artWork = await this.dbContext
               .ArtWorks
               .Include(h => h.Style)
               .Where(a => a.IsActive)
               .FirstAsync(a => a.Id.ToString() == artworkId);

            return new ArtWorkFormModel
            {
                Title = artWork.Title,
                Technique = artWork.Technique,
                CreatingYear = int.Parse(artWork.CreatingYear.Year.ToString()),
                Height = artWork.Height,
                Width = artWork.Width,
                ImageUrl = artWork.ImageUrl,
                StyleId = artWork.StyleId,
            };
        }

        public async Task<bool> IsArtistCreatorOfArtwork(string artworkId, string artistId)
        {
            ArtWork artWork = await this.dbContext
                .ArtWorks
                .Where(a => a.IsActive)
                .FirstAsync(a => a.Id.ToString() == artworkId);

            return artWork.ArtistId.ToString() == artistId;
        }

        public async Task<IEnumerable<IndexViewModel>> LastThreeArtWorksAsync()
        {
            IEnumerable<IndexViewModel> lastThreeArtWorks = await this.dbContext
                .ArtWorks
                .Where(a => a.IsActive)
                .OrderByDescending(a => a.CreatedOn)
                .Select(a => new IndexViewModel
                {
                    Id = a.Id.ToString(),
                    ImageUrl = a.ImageUrl,
                    Title = a.Title,
                })
                .Take(3)
                .ToArrayAsync();

            return lastThreeArtWorks;
        }
    }
}
