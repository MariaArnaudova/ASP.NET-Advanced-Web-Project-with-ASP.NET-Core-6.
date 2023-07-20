using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtStroke.Web.ViewModels.ArtWork
{
    public class ArtworkDeleteViewModel
    {
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Style { get; set; } = null!;

        [Display(Name = "Author name")]
        public string Author { get; set; } = null!;
    }
}
