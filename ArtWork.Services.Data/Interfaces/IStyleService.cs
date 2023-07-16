
using ArtStroke.Web.ViewModels.Styles;

namespace ArtStroke.Services.Data.Interfaces
{
    public interface IStyleService
    {
        Task<IEnumerable<ArtWorkStyleViewModel>> AllStylesAsync();

        Task<bool> StyleExistByIdAsync(int id);

        Task<IEnumerable<string>> AllStyleNameAsync();
    }
}
