using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArtStroke.Web.ViewModels.PrintDesign
{
    public class AllPrintsByUserIdModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        [Display(Name = "Width in Cm")]
        public int Width { get; set; }

        [Display(Name = "Height in Cm")]
        public int Height { get; set; }

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Designer name")]
        public string CreatorName { get; set; } = null!;

        public Guid? UserId { get; set; }
        public Guid ArtWorkId { get; set; }
    }
}
