

namespace ArtStroke.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using Interfaces;
    using Web.ViewModels.Home;
    using ArtStroke.Data;
    public class ArtWorkService : IArtWorkService
    {
        private readonly ArtStrokeDbContext dbContext;
        public ArtWorkService(ArtStrokeDbContext dbContext)
        {
            this.dbContext = dbContext;
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
