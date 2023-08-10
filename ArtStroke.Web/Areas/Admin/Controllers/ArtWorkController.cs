
namespace ArtStroke.Web.Areas.Admin.Controllers
{
    using ArtStroke.Services.Data.Interfaces;
    using ArtStroke.Web.Areas.Admin.ViewModels.ArtWorks;
    using ArtStroke.Web.Infrastructure.Extentions;
    using Microsoft.AspNetCore.Mvc;
    public class ArtWorkController : BaseAdminController
    {
        private readonly IArtistService artistService;
        private readonly IArtWorkService artWorkService;

        public ArtWorkController(IArtistService artistService,
            IArtWorkService artWorkService)
        {
            this.artistService = artistService;
            this.artWorkService = artWorkService;
        }

        public async Task<IActionResult> Mine()
        {
            string adminAsArtistId = await this.artistService.GetArtistIdByUserIdAsync(this.User.GetId()!);
            MyArtworksViewModel myArtworksViewModel = new MyArtworksViewModel()
            {
                AddedArtworks = await this.artWorkService.AllArtworksByArtistIdAsync(adminAsArtistId)
            };

            return this.View(myArtworksViewModel);
        }
    }
}
