
namespace ArtStroke.Web.ViewModels.NewTechniqueArt
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.NewTechniqueArt;
    public class AllTechniquesViewModel 
    { 

        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;


        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;


        [MaxLength(ImageUrlMaxLengt)]
        public string ImageUrl { get; set; } = null!;

        public string UserId { get; set; } = null!;
    }
}
