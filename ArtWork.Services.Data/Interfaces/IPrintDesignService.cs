using ArtStroke.Web.ViewModels.ArtWork;
using ArtStroke.Web.ViewModels.PrintDesigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtStroke.Services.Data.Interfaces
{
    public interface IPrintDesignService
    {
        Task<IEnumerable<AllPrintDesignsViewModel>> AllArtworksPrintsByUserIdAsync();
    }
}
