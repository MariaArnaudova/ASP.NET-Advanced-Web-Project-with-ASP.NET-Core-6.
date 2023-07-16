
using System.ComponentModel.DataAnnotations;

namespace ArtStroke.Web.ViewModels.ArtWork
{
    public class ArtworkAllViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;
        public string Style { get; set; } = null!;

        [Display(Name = "Has an individual disigned prints")]
        public bool IsDesignedInPrint { get; set; }
    }
}
