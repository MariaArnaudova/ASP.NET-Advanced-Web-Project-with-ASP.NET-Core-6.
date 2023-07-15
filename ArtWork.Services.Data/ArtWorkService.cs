

namespace ArtStroke.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using Interfaces;
    using Web.ViewModels.Home;
    using ArtStroke.Web.ViewModels.ArtWork;
    using ArtStroke.Data.Models;
    using ArtStroke.Data;

    public class ArtWorkService : IArtWorkService
    {
        private readonly ArtStrokeDbContext dbContext;
        public ArtWorkService(ArtStrokeDbContext dbContext)
        {
            this.dbContext = dbContext;
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

        public async Task<IEnumerable<IndexViewModel>> LastThreeArtWorksAsync()
        {
            IEnumerable<IndexViewModel> lastThreeArtWorks = await this.dbContext
                .ArtWorks
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
