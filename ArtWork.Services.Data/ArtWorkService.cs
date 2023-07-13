
using ArtStroke.Data;
using ArtStroke.Services.Data.Interfaces;
using ArtStroke.Web.ViewModels.Home;

namespace ArtStroke.Services.Data
{
    public class ArtWorkService : IArtWorkService
    {
        private readonly ArtStrokeDbContext dbContext;
        public ArtWorkService(ArtStrokeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<IndexViewModel>> LastThreeArtWorksAsync()
        {
            throw new NotImplementedException();
        }
    }
}
