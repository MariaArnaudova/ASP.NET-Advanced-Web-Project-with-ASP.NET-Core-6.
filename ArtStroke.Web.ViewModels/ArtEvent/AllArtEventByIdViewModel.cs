
namespace ArtStroke.Web.ViewModels.ArtEvent
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.ArtEvent;
    public class AllArtEventByIdViewModel
    {
        public string Id { get; set; } = null!;

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string PublicDate { get; set; } = null!;

        [Required]
        [MaxLength(InformationMaxLength)]
        public string Information { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLengt)]
        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;
    }
}
