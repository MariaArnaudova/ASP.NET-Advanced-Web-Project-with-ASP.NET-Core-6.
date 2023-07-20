
namespace ArtStroke.Web.ViewModels.ArtWork
{

    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.PrintDesign;
    public class ArtWorkBecomePrintDesignFormModel
    {
        [Required]
        [MaxLength(TitleMaxLengt)]
        public string Title { get; set; } = null!;

        [Required]
        [Range(MinWidth, MaxWidth)]
        [Display(Name = "Width in Cm")]
        public int Width { get; set; }

        [Required]
        [Range(MinHeight, MaxHeight)]
        [Display(Name = "Height in Cm")]
        public int Height { get; set; }

        [Required]
        [MaxLength(CreatorNameMaxLength)]
        [Display(Name = "Designer name")]
        public string CreatorName { get; set; } = null!;

        public string? Description { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLengt)]
        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;


    }
}
