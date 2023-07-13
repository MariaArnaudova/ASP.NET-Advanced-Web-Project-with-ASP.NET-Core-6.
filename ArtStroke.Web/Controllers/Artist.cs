
namespace ArtStroke.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class Artist : Controller
    {
        public async Task<IActionResult> Become()
        {
            return View();
        }
    }
}
