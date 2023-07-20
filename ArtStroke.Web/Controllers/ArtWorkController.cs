
namespace ArtStroke.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static Common.NotificationMessagesConstants;
    using ArtStroke.Services.Data.Interfaces;
    using ArtStroke.Web.Infrastructure.Extentions;
    using ArtStroke.Web.ViewModels.ArtWork;
    using ArtStroke.Services.Data.Models.ArtWork;
    using static ArtStroke.Common.EntityValidationConstants;

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
        public async Task<IActionResult> All([FromQuery] AllArtworksQueryModel queryModel)
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

            try
            {
                ArtWorkFormModel formModel = new ArtWorkFormModel()
                {
                    Styles = await this.styleService.AllStylesAsync()
                };

                return View(formModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error";

                return this.RedirectToAction("Index", "ArtWork");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArtWorkFormModel model)
        {
            bool isArtist = await this.artistService.HasArtistByUserIdAsync(this.User.GetId()!);

            if (!isArtist)
            {
                this.TempData[ErrorMessage] = "You must become an artist";
                return this.RedirectToAction("Become", "Artist");
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
                string artworkId = await this.artWorkService.CreateArtworkAsync(artistId!, model);
                return this.RedirectToAction("Details", "ArtWork", new { id = artworkId });
            }
            catch (Exception _)
            {

                this.ModelState.AddModelError(string.Empty, "Unexpected error at the creating artwork");
                model.Styles = await this.styleService.AllStylesAsync();
                return this.View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            List<ArtworkAllViewModel> myArtworks = new List<ArtworkAllViewModel>();

            string userId = this.User.GetId();
            bool isUserArtist = await this.artistService
                .HasArtistByUserIdAsync(userId);

            if (isUserArtist)
            {
                string? artistId =
                    await this.artistService.GetArtistIdByUserIdAsync(userId);
                myArtworks.AddRange(await this.artWorkService.AllArtworksByArtistIdAsync(artistId!));
            }
            else
            {
     
                return RedirectToAction("All", "ArtWork");               
            }

            return this.View(myArtworks);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool artworkExist = await this.artWorkService
                .ExistByIdAsync(id);

            if (!artworkExist)
            {
                this.TempData[ErrorMessage] = "Artwork with this id does not exist";
                return this.RedirectToAction("All", "ArtWork");
            }

            try
            {
                ArtworkDetailsViewModel viewModel = await this.artWorkService
                         .DetailsByArtistIdAsync(id);

                return View(viewModel); ;
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error";

                return this.RedirectToAction("Index", "ArtWork");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool artworkExist = await this.artWorkService
                .ExistByIdAsync(id);

            if (!artworkExist)
            {
                this.TempData[ErrorMessage] = "Artwork with this id does not exist";
                return this.RedirectToAction("All", "ArtWork");
            }

            bool isUserArtist = await this.artistService
                .HasArtistByUserIdAsync(this.User.GetId());

            if (!isUserArtist)
            {
                this.TempData[ErrorMessage] = "If you want to edit artwork,must become an artist";
                return this.RedirectToAction("Become", "Artist");
            }

            string artistId = await this.artistService.GetArtistIdByUserIdAsync(this.User.GetId()!);
            bool isArtistCreator = await this.artWorkService
                .IsArtistCreatorOfArtwork(id, artistId);

            if (!isArtistCreator)
            {
                this.TempData[ErrorMessage] = "If you want to edit artwork,must be creator on it";
                return this.RedirectToAction("Mine", "House");
            }

            try
            {
                ArtWorkFormModel formModel = await this.artWorkService
                         .GetArtworkForEditByIdAsync(id);
                formModel.Styles = await this.styleService.AllStylesAsync();

                return this.View(formModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error";

                return this.RedirectToAction("Index", "ArtWork");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, ArtWorkFormModel model)
        {

            if (!ModelState.IsValid)
            {
                model.Styles = await this.styleService.AllStylesAsync();
                return this.View(model);
            }

            bool artworkExist = await this.artWorkService
               .ExistByIdAsync(id);

            if (!artworkExist)
            {
                this.TempData[ErrorMessage] = "Artwork with this id does not exist";
                return this.RedirectToAction("All", "ArtWork");
            }

            bool isUserArtist = await this.artistService
                .HasArtistByUserIdAsync(this.User.GetId());

            if (!isUserArtist)
            {
                this.TempData[ErrorMessage] = "If you want to edit artwork,must become an artist";
                return this.RedirectToAction("Become", "Artist");
            }

            string artistId = await this.artistService.GetArtistIdByUserIdAsync(this.User.GetId()!);
            bool isArtistCreator = await this.artWorkService
                .IsArtistCreatorOfArtwork(id, artistId);

            if (!isArtistCreator)
            {
                this.TempData[ErrorMessage] = "If you want to edit artwork,must be creator on it";
                return this.RedirectToAction("Mine", "House");
            }

            try
            {
                await this.artWorkService.EditArtworkBtIdInFormModelAsync(id, model);
            }
            catch (Exception ex)
            {

                this.ModelState.AddModelError(string.Empty, "Unexpected error");
                model.Styles = await this.styleService.AllStylesAsync();

                return this.View(model);
            }

            return this.RedirectToAction("Details", "ArtWork", new { id });
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
           
            bool artworkExist = await this.artWorkService
               .ExistByIdAsync(id);

            if (!artworkExist)
            {
                this.TempData[ErrorMessage] = "Artwork with this id does not exist";
                return this.RedirectToAction("All", "ArtWork");
            }

            bool isUserArtist = await this.artistService
                .HasArtistByUserIdAsync(this.User.GetId());

            if (!isUserArtist)
            {
                this.TempData[ErrorMessage] = "If you want to edit artwork,must become an artist";
                return this.RedirectToAction("Become", "Artist");
            }

            string artistId = await this.artistService.GetArtistIdByUserIdAsync(this.User.GetId()!);
            bool isArtistCreator = await this.artWorkService
                .IsArtistCreatorOfArtwork(id, artistId);

            if (!isArtistCreator)
            {
                this.TempData[ErrorMessage] = "If you want to edit artwork,must be creator on it";
                return this.RedirectToAction("Mine", "House");
            }

            try
            {
                ArtworkDeleteViewModel viewModel =
                    await this.artWorkService.GetArtworkDeleteBtIdInAsync(id);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error";

                return this.RedirectToAction("Index", "ArtWork");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, ArtworkDeleteViewModel model)
        {
            bool artworkExist = await this.artWorkService
               .ExistByIdAsync(id);

            if (!artworkExist)
            {
                this.TempData[ErrorMessage] = "Artwork with this id does not exist";
                return this.RedirectToAction("All", "ArtWork");
            }

            bool isUserArtist = await this.artistService
                .HasArtistByUserIdAsync(this.User.GetId());

            if (!isUserArtist)
            {
                this.TempData[ErrorMessage] = "If you want to edit artwork,must become an artist";
                return this.RedirectToAction("Become", "Artist");
            }

            string artistId = await this.artistService.GetArtistIdByUserIdAsync(this.User.GetId()!);
            bool isArtistCreator = await this.artWorkService
                .IsArtistCreatorOfArtwork(id, artistId);

            if (!isArtistCreator)
            {
                this.TempData[ErrorMessage] = "If you want to edit artwork, must be creator on it";
                return this.RedirectToAction("Mine", "House");
            }

            try
            {
                await this.artWorkService.DeleteArtworkByIdAsync(id);
                this.TempData[WarningMessage] = $"The artwork {model.Title} was successfully deleted.";
                return this.RedirectToAction("Mine", "ArtWork");
            }
            catch (Exception ex)
            {
                this.TempData[ErrorMessage] = "Unexpected error";

                return this.RedirectToAction("Index", "ArtWork");
            }
        }


        [HttpGet]
        public async Task<IActionResult> Design (string id)
        {
            string usertId = this.User.GetId()!;

            if(usertId == null)
            {
                this.TempData[ErrorMessage] = "User with this id does not exist";
                return this.RedirectToAction("All", "ArtWork");
            }

            bool artworkExist = await this.artWorkService
              .ExistByIdAsync(id);

            if (!artworkExist)
            {
                this.TempData[ErrorMessage] = "Artwork with this id does not exist";
                return this.RedirectToAction("All", "ArtWork");
            }

            try
            {
                ArtWorkBecomePrintDesignFormModel formModel = new ArtWorkBecomePrintDesignFormModel();
                
                return View(formModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error";

                return this.RedirectToAction("Index", "ArtWork");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Design(string id, ArtWorkBecomePrintDesignFormModel model)
        {
            string usertId = this.User.GetId()!;

            if (usertId == null)
            {
                this.TempData[ErrorMessage] = "User with this id does not exist";
                return this.RedirectToAction("All", "ArtWork");
            }

            bool artworkExist = await this.artWorkService
              .ExistByIdAsync(id);

            if (!artworkExist)
            {
                this.TempData[ErrorMessage] = "Artwork with this id does not exist";
                return this.RedirectToAction("All", "ArtWork");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {

                string printId = await this.artWorkService.CreateDesignArtworkAsync(usertId, id, model);
                return this.RedirectToAction("Details", "ArtWork", new { id = id });
            }
            catch (Exception _)
            {

                this.ModelState.AddModelError(string.Empty, "Unexpected error at the creating print design");
                return this.View(model);
            }

        }
    }

}

