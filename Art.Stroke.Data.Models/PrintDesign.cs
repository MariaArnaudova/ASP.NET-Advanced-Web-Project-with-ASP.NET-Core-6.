
namespace ArtStroke.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Reflection.Metadata;
    using static Common.EntityValidationConstants.PrintDesign;
    public class PrintDesign
    {
        public PrintDesign()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        //public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLengt)]
        public string Title { get; set; } = null!;

        [Required]
        [Range(MinWidth, int.MaxValue)]
        public int Width { get; set; }

        [Required]
        [Range(MinHeight, int.MaxValue)]
        public int Height { get; set; }

        [Required]
        [MaxLength(CreatorNameMaxLength)]
        public string CreatorName { get; set; } = null!;

        public string? Description { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLengt)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public Guid? UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;

        public bool IsActive { get; set; }  
    
        public Guid? ArtWorkId { get; set; }

        [ForeignKey("ArtWorkId")]
        public ArtWork? ArtWork { get; set; }

    }
}
