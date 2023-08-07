
namespace ArtStroke.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ArtStroke.Data.Models;
    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserStore<ApplicationUser> userStore;

        public UserController()
        {

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
