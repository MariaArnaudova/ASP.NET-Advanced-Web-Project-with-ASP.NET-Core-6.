
using ArtStroke.Services.Data.Models.ArtWork;
using ArtStroke.Web.ViewModels.ArtWork;
using ArtStroke.Web.ViewModels.NewTechniqueArt;

namespace ArtStroke.Services.Data.Interfaces
{

    public interface INewTechniqueArtService
    {
        Task<string> CreateNewTechnique(string userId, TechniqueArtsFormModel model);
        Task<IEnumerable<AllTechniquesViewModel>> AllAsync();
    }
}
