
namespace ArtStroke.Services.Data.Interfaces
{
    using Models.ArtWork;
    using Web.ViewModels.Home;
    using Web.ViewModels.ArtWork;
    public interface IArtWorkService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeArtWorksAsync();
        Task CreateArtworkAsync(string artistId, ArtWorkFormModel model);

        Task<IEnumerable<ArtworkAllViewModel>> AllArtworksByArtistIdAsync(string artistId);
        Task<AllArtworksFilteredServiceModel> AllAsync(AllArtworksQueryModel queryModel);
        Task<ArtworkDetailsViewModel> DetailsByArtistIdAsync(string artworkId);

        Task<ArtWorkFormModel> GetArtworkForEditByIdAsync(string artworkId);

        Task<bool> ExistByIdAsync(string artworkId);
    }
}
