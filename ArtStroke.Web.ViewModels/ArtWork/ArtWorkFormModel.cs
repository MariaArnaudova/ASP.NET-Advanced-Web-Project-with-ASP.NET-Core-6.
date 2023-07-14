

namespace ArtStroke.Web.ViewModels.ArtWork
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Artwork;
    using ArtStroke.Web.ViewModels.Styles;

    public class ArtWorkFormModel
    {

        public ArtWorkFormModel()
        {
            this.Styles = new HashSet<ArtWorkStyleViewModel>();
        }

        [Required]
        [StringLength(TitleMaxLengt, MinimumLength = TitleMinLengt)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(TechniqueMaxLengt, MinimumLength = TechniqueMinLengt)]
        public string Technique { get; set; } = null!;


        [Required]
        [Range(MinWidth, int.MaxValue)]
        public int Width { get; set; }

        [Required]
        [Range(MinHeight, int.MaxValue)]
        public int Height { get; set; }

        [Required]
        [MaxLength(ImageUrlMaxLengt)]
        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Display(Name = "Date of creating")]
        public DateTime CreatingYear { get; set; }

        public int StyleId { get; set; }

        [Required]
        public IEnumerable<ArtWorkStyleViewModel> Styles { get; set; } = null!;
    }
}
