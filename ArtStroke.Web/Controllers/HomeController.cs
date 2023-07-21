﻿

namespace ArtStroke.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;

    using ArtStroke.Web.ViewModels.Home;
    using ArtStroke.Services.Data.Interfaces;

    public class HomeController : Controller
    {
        private readonly IArtWorkService artWorkService;
        public HomeController(IArtWorkService artWorkService)
        {
            this.artWorkService = artWorkService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<IndexViewModel> viewModels =
             await this.artWorkService.LastThreeArtWorksAsync();

            return View(viewModels);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return this.View("Error404");
            }
            return View();
        }
    }
}