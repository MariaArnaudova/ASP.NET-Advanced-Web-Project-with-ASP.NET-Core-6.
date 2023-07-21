
namespace ArtStroke.Web.ViewModels.NewTechniqueArt
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.NewTechniqueArt;
    public class TechniqueArtsFormModel
    {

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;


        [Required]
        [MaxLength(ImageUrlMaxLengt)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public Guid UserId { get; set; }
    }
}
