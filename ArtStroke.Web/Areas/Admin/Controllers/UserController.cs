
namespace ArtStroke.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ArtStroke.Services.Data.Interfaces;
    using ArtStroke.Web.ViewModels.User;

    using static ArtStroke.Common.EntityValidationConstants;


    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("User/All")]
        public async Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> users = await this.userService.AllAsync();

            return this.View(users);
        }

    }
}
