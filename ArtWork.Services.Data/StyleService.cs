
namespace ArtStroke.Services.Data
{
    using ArtStroke.Data;
    using ArtStroke.Services.Data.Interfaces;
    using ArtStroke.Web.ViewModels.Styles;
    using Microsoft.EntityFrameworkCore;

    public class StyleService : IStyleService
    {
        private readonly ArtStrokeDbContext dbContext;
        public StyleService(ArtStrokeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<ArtWorkStyleViewModel>> AllStylesAsync()
        {
            IEnumerable<ArtWorkStyleViewModel> allStyles = await this.dbContext
                .Styles
                .AsNoTracking()
                .Select(s => new ArtWorkStyleViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                })
                .ToArrayAsync();

            return allStyles;
        }

        public async Task<bool> StyleExistByIdAsync(int id)
        {
            bool result = await this.dbContext
                 .Styles
                 .AsNoTracking()
                 .AnyAsync(s => s.Id == id);
            return result;
        }
    }
}
