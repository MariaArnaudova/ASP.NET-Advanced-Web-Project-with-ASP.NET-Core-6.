
namespace ArtStroke.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Reflection.Metadata;
    using static Common.EntityValidationConstants.PrintDesign;
    public class PrintDesign
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(MinWidth, int.MaxValue)]
        public int Width { get; set; }

        [Required]
        [Range(MinHeight, int.MaxValue)]
        public int Height { get; set; }

        [Required]
        [MaxLength(CreatorNameMaxLength)]
        public string CreatorName { get; set; } = null!;

        [Required]
        public Guid? UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;

        public Guid ArtWorkId { get; set; } 

        public ArtWork ArtWork { get; set; } = null!;

    }
}
