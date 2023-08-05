namespace ArtStroke.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using ArtStroke.Services.Data.Interfaces;
    using ArtStroke.Web.ViewModels.PrintDesign;
    using ArtStroke.Web.Infrastructure.Extentions;
    using static Common.NotificationMessagesConstants;
    using ArtStroke.Data.Models;
    using ArtStroke.Web.ViewModels.ArtWork;

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
                return this.View(allPrints);
            }
            catch (Exception)
            {
                return RedirectToAction("All", "ArtWork");
              
            }

        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            //bool printExist = await this.printDesignService
            //       .ExistPrintByIdAsync(id);
         
            PrintDesignDetailsViewModel currentPrint = await this.printDesignService.GetPrintById(id);

            bool artWorkBecomeToPrintExist = await this.artWorkService
                .IsMadeOnPrintDesign(currentPrint.ArtWorkId);

            if (/*!printExist  ||*/  !artWorkBecomeToPrintExist)
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


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool printExist = await this.printDesignService
                .ExistByIdAsync(id);

            if (!printExist)
            {
                this.TempData[ErrorMessage] = "Print with this id does not exist";
                return this.RedirectToAction("MinePrints", "PrintDesign");
            }

            string userId = this.User.GetId()!;
            bool isUserCreator = await this.printDesignService
                .IsUserCreatorOfPrint(id, userId);

            if (!isUserCreator)
            {
                this.TempData[ErrorMessage] = "If you want to edit print,must be creator on it";
                return this.RedirectToAction("MinePrints", "PrintDesign");
            }
           

            try
            {
                PrintCreateFormModel formModel = await this.printDesignService
                         .GetPrintForEditByIdAsync(id);
                //formModel.UserId = userId;

                return this.View(formModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error";

                return this.RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, PrintCreateFormModel formModel)
        {

            if (!ModelState.IsValid)
            {
                return this.View(formModel);
            }

            bool printExist = await this.printDesignService
              .ExistByIdAsync(id);

            if (!printExist)
            {
                this.TempData[ErrorMessage] = "Print with this id does not exist";
                return this.RedirectToAction("MinePrints", "PrintDesign");
            }

            string userId = this.User.GetId()!;
            bool isUserCreator = await this.printDesignService
                .IsUserCreatorOfPrint(id, userId);

            if (!isUserCreator)
            {
                this.TempData[ErrorMessage] = "If you want to edit print,must be creator on it";
                return this.RedirectToAction("MinePrints", "PrintDesign");
            }

            try
            {
                await this.printDesignService.EditPrintBtIdInFormModelAsync(id, formModel);
            }
            catch (Exception ex)
            {

                this.ModelState.AddModelError(string.Empty, "Unexpected error");
                return this.View(formModel);
            }

            return this.RedirectToAction("Details", "PrintDesign", new { id });
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool printExist = await this.printDesignService
                    .ExistByIdAsync(id);

            if (!printExist)
            {
                this.TempData[ErrorMessage] = "Print with this id does not exist";
                return this.RedirectToAction("All", "PrintDesign");
            }

            string userId = this.User.GetId()!;
            bool isUserCreator = await this.printDesignService
                .IsUserCreatorOfPrint(id, userId);

            if (!isUserCreator)
            {
                this.TempData[ErrorMessage] = "If you want to delete print, must be creator on it";
                return this.RedirectToAction("All", "PrintDesign");
            }

            try
            {
                PrintDeleteViewModel viewModel =
                     await this.printDesignService.GetPrintDeleteBtIdInAsync(id);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error";

                return this.RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, PrintDeleteViewModel model)
        {
            bool printExist = await this.printDesignService
                  .ExistByIdAsync(id);

            if (!printExist)
            {
                this.TempData[ErrorMessage] = "Print with this id does not exist";
                return this.RedirectToAction("All", "PrintDesign");
            }

            string userId = this.User.GetId()!;
            bool isUserCreator = await this.printDesignService
                .IsUserCreatorOfPrint(id, userId);

            if (!isUserCreator)
            {
                this.TempData[ErrorMessage] = "If you want to delete print, must be creator on it";
                return this.RedirectToAction("All", "PrintDesign");
            }

            try
            {
                await this.printDesignService.DeletePrintDesignByIdAsync(id);
                this.TempData[WarningMessage] = $"The print {model.Title} was successfully deleted.";
                return this.RedirectToAction("MinePrints", "PrintDesign");
            }
            catch (Exception ex)
            {
                this.TempData[ErrorMessage] = "Unexpected error";

                return this.RedirectToAction("Index", "ArtWork");
            }
        }
    }
}
