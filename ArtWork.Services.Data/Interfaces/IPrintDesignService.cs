
namespace ArtStroke.Services.Data.Interfaces
{
    using ArtStroke.Web.ViewModels.PrintDesigns;
    public interface IPrintDesignService
    {
        Task<IEnumerable<AllPrintDesignsByArtworkIdViewModel>> AllArtworksPrintsByUserIdAndArtworkIdAsync(string artworkId, string userId);
        Task<PrintDesignDetailsViewModel> GetPrintById(string printId);
        Task<bool> ExistPrintByIdAsync(string printId);
        Task<int> GetPrintsCollectionByidCount(string printId);
        Task<IEnumerable<AllPrintsByUserIdModel>> GetPrintsByUserId(string userId);
        Task<bool> IsCratedPrintByUserIdAsync(string artworkId, string userId);

    }
}
