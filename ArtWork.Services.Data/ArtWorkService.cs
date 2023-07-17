

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

        public async Task CreateArtworkAsync(string artistId, ArtWorkFormModel model)
        {
            int year = model.CreatingYear;
            DateTime date = new DateTime(year, 1, 1);

            ArtWork artwor = new ArtWork()
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

            await this.dbContext.ArtWorks.AddAsync(artwor);
            await this.dbContext.SaveChangesAsync();

        }

        public async Task<ArtworkDetailsViewModel?> DetailsByArtistIdAsync(string artworkId)
        {
            ArtWork? artWork = await this.dbContext
                .ArtWorks
                .Include(h => h.Style)
                .Include(h => h.Artist)
                .Where(a => a.IsActive)
                .FirstOrDefaultAsync(a => a.Id.ToString() == artworkId);

            if(artWork == null)
            {
                return null;
            }

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
                Artist = new ArtistInfoOnArtworkViewModel
                {
                    Biography = artWork.Artist.Biography,
                    Name = artWork.Artist.Name,
                }
            };
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
