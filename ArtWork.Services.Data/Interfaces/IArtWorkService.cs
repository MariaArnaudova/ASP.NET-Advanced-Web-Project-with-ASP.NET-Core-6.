
using ArtStroke.Web.ViewModels.ArtWork;
using ArtStroke.Web.ViewModels.Home;

namespace ArtStroke.Services.Data.Interfaces
{
    public interface IArtWorkService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeArtWorksAsync();
        Task CreateArtworkAsync(string artistId, ArtWorkFormModel model);
    }
}
