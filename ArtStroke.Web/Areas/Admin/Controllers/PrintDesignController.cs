
namespace ArtStroke.Web.Areas.Admin.Controllers
{
    using ArtStroke.Services.Data.Interfaces;
    using ArtStroke.Web.ViewModels.PrintDesign;
    using Microsoft.AspNetCore.Mvc;
    public class PrintDesignController : BaseAdminController
    {
        private readonly IPrintDesignService printDesignService;

        public PrintDesignController(IPrintDesignService printDesignService)
        {
            this.printDesignService = printDesignService;
        }

       
        [HttpGet]
        public async Task<IActionResult> All()
        {
            //IEnumerable<AllPrintDesignsViewModel> allPrints = await this.printDesignService.AllAsync();
            IEnumerable<AllPrintDesignsViewModel> allPrints = await this.printDesignService.AllAsync();

            return this.View(allPrints);
        }
    }
}
