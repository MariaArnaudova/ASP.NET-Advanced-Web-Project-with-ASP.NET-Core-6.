


namespace ArtStroke.Web.ViewModels.PrintDesign
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.PrintDesign;
    public class PrintCreateFormModel
    {
        //public int Id { get; set; }
        public Guid Id { get; set; }

        [Required]
        [StringLength(TitleMaxLengt, MinimumLength = TitleMinLengt)]
        public string Title { get; set; } = null!;

        [Required]
        [Range(MinWidth, MaxWidth)]
        public int Width { get; set; }

        [Required]
        [Range(MinHeight, MaxHeight)]
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

        public bool IsActive { get; set; }

        public Guid? ArtWorkId { get; set; }
    }
}
