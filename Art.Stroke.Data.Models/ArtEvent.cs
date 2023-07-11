
namespace ArtStroke.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.ArtEvent;
    public class ArtEvent
    {
        [Key]
        public int Id { get; set; }

        [Required]  
        public string Title { get; set; } = null!;

        [Required]
        public DateTime PublicDate { get; set; }

        [Required]
        [MaxLength(InformationMaxLength)]
        public string Information { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLengt)]
        public string ImageUrl { get; set; } = null!;
    }
}
