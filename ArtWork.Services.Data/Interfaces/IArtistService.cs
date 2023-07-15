using ArtStroke.Web.ViewModels.Artist;
using ArtStroke.Web.ViewModels.ArtWork;

namespace ArtStroke.Services.Data.Interfaces
{
    public interface IArtistService
    {
        Task<bool> HasArtistByUserIdAsync(string userId);

        Task<bool> ArtistExistByPhonenumberAsync(string phonenumber);

        Task Create(string userId, BecomeArtistFormModel model);

        Task<string> GetArtistIdByUserIdAsync(string userId);
       
    }
}
