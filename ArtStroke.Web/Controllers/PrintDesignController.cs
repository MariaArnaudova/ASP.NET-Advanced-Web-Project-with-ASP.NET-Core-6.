namespace ArtStroke.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using ArtStroke.Services.Data.Interfaces;
    using ArtStroke.Web.ViewModels.PrintDesigns;
    using ArtStroke.Web.Infrastructure.Extentions;
    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class PrintDesignController : Controller
    {
        private readonly IArtistService artistService;
        private readonly IArtWorkService artWorkService;
        private readonly IPrintDesignService printDesignService;
        public PrintDesignController(
                     IArtistService artistService,
            IArtWorkService artWorkService,
            IPrintDesignService printDesignService)
        {
            this.artistService = artistService;
            this.artWorkService = artWorkService;
            this.printDesignService = printDesignService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetPrints(string id)
        {
            List<AllPrintDesignsByArtworkIdViewModel> allPrints = new List<AllPrintDesignsByArtworkIdViewModel>() { };
            bool artworkExist = await this.artWorkService.ExistByIdAsync(id);
            string userId = this.User.GetId();

            if (!artworkExist)
            {
                this.TempData[ErrorMessage] = "Artwork with this id does not exist";
                return this.RedirectToAction("Details", "ArtWork");
            }

            try
            {
                allPrints.AddRange(await this.printDesignService.AllArtworksPrintsByUserIdAndArtworkIdAsync(id, userId));
                return View(allPrints);
            }
            catch (Exception)
            {
                return RedirectToAction("All", "ArtWork");
                throw;
            }

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool printExist = await this.printDesignService
                   .ExistPrintByIdAsync(id);

            bool artWorkBecomeToPrintExist = await this.artWorkService
                .IsMadeOnPrintDesign(id);

            if (!printExist || !artWorkBecomeToPrintExist)
            {
                this.TempData[ErrorMessage] = "Print with this id does not exist";
                return this.RedirectToAction("GetPrints", "PrintDesign");
            }

            try
            {
                PrintDesignDetailsViewModel model = await this.printDesignService.GetPrintById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("All", "ArtWork");
                throw;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> MinePrints()
        {
            List<AllPrintsByUserIdModel> myPrints = new List<AllPrintsByUserIdModel>();
            string userId = this.User.GetId()!;
            var allprints = await this.printDesignService.GetPrintsByUserId(userId);
            try
            {
                myPrints.AddRange(allprints);
                return View(myPrints);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error";

                return this.RedirectToAction("Index", "ArtWork");
            }
        }

    }
}
