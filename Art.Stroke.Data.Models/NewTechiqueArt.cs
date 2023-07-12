
namespace ArtStroke.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.NewTechiqueArt;
    public class NewTechiqueArt
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLengt)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;


        [Required]
        [MaxLength(ImageUrlMaxLengt)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;


    }
}
