
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
        public string UserId { get; set; } = null!;
        
    }
}
