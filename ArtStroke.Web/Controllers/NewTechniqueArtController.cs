
namespace ArtStroke.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using ArtStroke.Services.Data.Interfaces;
    using ArtStroke.Web.ViewModels.NewTechniqueArt;
    using ArtStroke.Web.Infrastructure.Extentions;
    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class NewTechniqueArtController : Controller
    {
        private readonly INewTechniqueArtService techniqueArtService;
        public NewTechniqueArtController(INewTechniqueArtService techniqueArtService)
        {
            this.techniqueArtService = techniqueArtService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            string userId = this.User.GetId();

            if (userId == null)
            {
                this.TempData[ErrorMessage] = "User with this id does not exist, you must to login";
                return this.RedirectToAction("Index", "Home");
            }

            try
            {
                TechniqueArtsFormModel formModel = new TechniqueArtsFormModel();
                return View(formModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error";

                return this.RedirectToAction("Index", "Home");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(TechniqueArtsFormModel formModel)
        {
            string userId = this.User.GetId();

            if (userId == null)
            {
                this.TempData[ErrorMessage] = "User with this id does not exist";
                return this.RedirectToAction("Index", "Home");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(formModel);
            }

            try
            {
                this.TempData[SuccessMessage] = "Technique was created successfully!";
                await this.techniqueArtService.CreateNewTechnique(userId, formModel);
                return View(formModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error";

                return this.RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]

        public async Task<IActionResult> All()
        {
            List<AllTechniquesViewModel> allTechniquesViewModels= new List<AllTechniquesViewModel>();

            IEnumerable<AllTechniquesViewModel> model =
               await this.techniqueArtService.AllAsync();
            allTechniquesViewModels.AddRange(model);

            return this.View(allTechniquesViewModels);

        }
    }
}
