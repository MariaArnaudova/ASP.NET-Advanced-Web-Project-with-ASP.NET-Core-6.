
namespace ArtStroke.Web.ViewModels.ArtEvent
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.ArtEvent;
    public class ArtEventFormModel
    {
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int PublicDate { get; set; }

        [Required]
        [MaxLength(InformationMaxLength)]
        public string Information { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLengt)]
        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;
    }
}
