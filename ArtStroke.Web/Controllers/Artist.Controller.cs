
namespace ArtStroke.Web.Controllers
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Services.Data.Interfaces;
    using Infrastructure.Extentions;
    using static Common.NotificationMessagesConstants;
    using ArtStroke.Web.ViewModels.Artist;

    [Authorize]
    public class ArtistController : Controller
    {
        private readonly IArtistService artistService;

        public ArtistController(IArtistService artistService)
        {
            this.artistService = artistService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = this.User.GetId();

            bool isArtist = await this.artistService.HasArtistByUserIdAsync(userId);

            if (isArtist)
            {
                this.TempData[ErrorMessage] = "You are already an artist!";

                return this.RedirectToAction("Index", "Home");
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Become(BecomeArtistFormModel model)
        {
            string? userId = this.User.GetId();

            bool isArtist = await this.artistService.HasArtistByUserIdAsync(userId);

            if (isArtist)
            {
                this.TempData[ErrorMessage] = "You are already an artist!";

                return this.RedirectToAction("Index", "Home");
            }


            bool isPhonenumberFreeToUse =
                await this.artistService.ArtistExistByPhonenumberAsync(model.PhoneNumber);
            if (isPhonenumberFreeToUse)
            {
                this.ModelState.AddModelError(nameof(model.PhoneNumber), "Artist allready exist with the same phonenumber.");
            }

            if (this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                await this.artistService.Create(userId, model);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error in registering to become an artist";
                return this.RedirectToAction("Index", "Home");
            }
            return this.RedirectToAction("All", "House");
        }
    }
}
