
namespace ArtStroke.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ArtStroke.Services.Data.Interfaces;
    using ArtStroke.Web.Infrastructure.Extentions;
    using ArtStroke.Web.ViewModels.ArtWork;
    using static Common.NotificationMessagesConstants;
    using ArtStroke.Data.Models;
    using System.Globalization;
    using ArtStroke.Services.Data.Models.ArtWork;

    [Authorize]
    public class ArtWorkController : Controller
    {
        private readonly IStyleService styleService;
        private readonly IArtistService artistService;
        private readonly IArtWorkService artWorkService;

        public ArtWorkController(IStyleService styleService,
            IArtistService artistService,
            IArtWorkService artWorkService)
        {
            this.styleService = styleService;
            this.artistService = artistService;
            this.artWorkService = artWorkService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllArtworksQueryModel queryModel)
        {
            AllArtworksFilteredServiceModel serviceModel =
                await this.artWorkService.AllAsync(queryModel);

            queryModel.Artwoks = serviceModel.Artworks;
            queryModel.TotalArtworks = serviceModel.CountTotalArtworks;
            queryModel.Styles = await this.styleService.AllStyleNameAsync();

            return this.View(queryModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isArtist = await this.artistService.HasArtistByUserIdAsync(this.User.GetId()!);

            if (!isArtist)
            {
                this.TempData[ErrorMessage] = "You must become an artist";
                return this.RedirectToAction("Become", "Artis");
            }

            ArtWorkFormModel formModel = new ArtWorkFormModel()
            {
                Styles = await this.styleService.AllStylesAsync()
            };

            return View(formModel);
        }


        [HttpPost]
        public async Task<IActionResult> Add(ArtWorkFormModel model)
        {
            bool isArtist = await this.artistService.HasArtistByUserIdAsync(this.User.GetId()!);

            if (!isArtist)
            {
                this.TempData[ErrorMessage] = "You must become an artist";
                return this.RedirectToAction("Become", "Artis");
            }

            bool isStyleExists =
                await this.styleService.StyleExistByIdAsync(model.StyleId);

            if (!isStyleExists)
            {
                this.ModelState.AddModelError(nameof(model.StyleId), "This style is invalid and does not exist");
            }

            if (!this.ModelState.IsValid)
            {
                model.Styles = await this.styleService.AllStylesAsync();

                return this.View(model);
            }

            try
            {
                string? artistId =
                  await this.artistService.GetArtistIdByUserIdAsync(this.User.GetId()!);
                  await this.artWorkService.CreateArtworkAsync( artistId!, model);
            }
            catch (Exception _)
            {

                this.ModelState.AddModelError(string.Empty, "Unexpected error at the creating artwork");
                model.Styles = await this.styleService.AllStylesAsync();

                return this.View(model);
            }

            return this.RedirectToAction("All", "ArtWork");
        }
    }

}
