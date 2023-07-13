
using ArtStroke.Web.ViewModels.Home;

namespace ArtStroke.Services.Data.Interfaces
{
    public interface IArtWorkService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeArtWorksAsync();
    }
}
