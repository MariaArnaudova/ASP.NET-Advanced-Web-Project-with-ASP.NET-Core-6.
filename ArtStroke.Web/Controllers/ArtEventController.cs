

namespace ArtStroke.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ArtStroke.Services.Data.Interfaces;
    using ArtStroke.Web.ViewModels.ArtEvent;
    using ArtStroke.Web.Infrastructure.Extentions;
    using static Common.NotificationMessagesConstants;
    using ArtStroke.Web.ViewModels.ArtWork;

    [Authorize]
    public class ArtEventController : Controller
    {
        private readonly IArtEventService artEventService;
        public ArtEventController(IArtEventService artEventService)
        {
            this.artEventService = artEventService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllAsync()
        {
            List<AllArtEventByIdViewModel> allArtEvents = new List<AllArtEventByIdViewModel>() { };

            try
            {
                allArtEvents.AddRange(await this.artEventService.AllArtEventsAsync());
                return this.View(allArtEvents);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");

            }

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            string usertId = this.User.GetId()!;

            if (usertId == null)
            {
                this.TempData[ErrorMessage] = "User with this id does not exist";
                return this.RedirectToAction("All", "ArtEvent");
            }

            try
            {
                ArtEventFormModel formModel = new ArtEventFormModel();

                return View(formModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error";

                return this.RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ArtEventFormModel model)
        {         

            if (!this.ModelState.IsValid)
            {

                return this.View(model);
            }

            try
            {
                string artEventId = await this.artEventService.CreateEventAsync(model);
                return this.RedirectToAction("All", "ArtEvent");
            }
            catch (Exception _)
            {

                this.ModelState.AddModelError(string.Empty, "Unexpected error at the creating artwork");
                return this.View(model);
            }
        }
    }
}
