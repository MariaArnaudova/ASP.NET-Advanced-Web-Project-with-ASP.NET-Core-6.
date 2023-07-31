
namespace ArtStroke.Services.Data.Interfaces
{
    using ArtStroke.Web.ViewModels.PrintDesign;
    public interface IPrintDesignService
    {
        Task<IEnumerable<AllPrintDesignsByArtworkIdViewModel>> AllArtworksPrintsByUserIdAndArtworkIdAsync(string artworkId, string userId);
        Task<PrintDesignDetailsViewModel> GetPrintById(string printId);
        Task<bool> ExistPrintByIdAsync(string printId);
        Task<int> GetPrintsCollectionByidCount(string printId);
        Task<IEnumerable<AllPrintsByUserIdModel>> GetPrintsByUserId(string userId);
        Task<bool> IsCratedPrintByUserIdAsync(string printId, string userId);
        Task<bool> ExistByIdAsync( string printId);

        Task<bool> IsUserCreatorOfPrint(string printId, string userId);
        Task<PrintCreateFormModel> GetPrintForEditByIdAsync(string printId);
        Task EditPrintBtIdInFormModelAsync(string printId, PrintCreateFormModel model);

        Task<PrintDeleteViewModel> GetPrintDeleteBtIdInAsync(string printId);

        Task DeletePrintDesignByIdAsync(string printId);

    }
}
