
namespace ArtStroke.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.NewTechniqueArt;
    public class NewTechniqueArt
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public bool IsActive { get; set; }

        [Required]
        [MaxLength(ImageUrlMaxLengt)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;


    }
}
