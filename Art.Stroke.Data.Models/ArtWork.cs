
namespace ArtStroke.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidationConstants.Artwork;
    public class ArtWork
    {
        public ArtWork()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLengt)]
        public string Title { get; set; } = null!;

        public int StyleId { get; set; }

        [ForeignKey("Style")]
        public virtual Style Style { get; set; } = null!;

        [Required]
        [Range(MinWidth, int.MaxValue)]
        public int Width { get; set; }

        [Required]
        [Range(MinHeight, int.MaxValue)]
        public int Height { get; set; }

        [Required]
        [MaxLength(ImageUrlMaxLengt)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public DateTime CreatingYear { get; set; }

        public Guid ArtistId { get; set; }

        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; } = null!;

    }
}