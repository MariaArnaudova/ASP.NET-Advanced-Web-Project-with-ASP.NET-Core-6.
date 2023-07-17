
namespace ArtStroke.Services.Data
{
    using ArtStroke.Web.ViewModels.PrintDesigns;
    using ArtStroke.Data;
    using Microsoft.EntityFrameworkCore;
    using ArtStroke.Services.Data.Interfaces;

    public class PrintDesignService : IPrintDesignService
    {

        private readonly ArtStrokeDbContext dbContext;
        public PrintDesignService(ArtStrokeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllPrintDesignsViewModel>> AllArtworksPrintsByUserIdAsync()
        {
            IEnumerable<AllPrintDesignsViewModel> allPrintsByUser = await this.dbContext
                 .PrintDesigns
                 .Where(p => p.IsActive)
                 .Select(p => new AllPrintDesignsViewModel()
                 {
                     Id = p.Id.ToString(),
                     UserId = p.UserId,
                     ArtWorkId = p.ArtWorkId.GetValueOrDefault(),
                     CreatorName = p.CreatorName,
                     Height = p.Height,
                     Width = p.Width,
                 }).ToArrayAsync();

            return allPrintsByUser;
        }
    }
}
