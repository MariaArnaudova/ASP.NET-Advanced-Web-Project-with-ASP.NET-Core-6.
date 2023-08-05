


namespace ArtStroke.Web.ViewModels.PrintDesign
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.PrintDesign;
    public class PrintCreateFormModel
    {
        public string Id { get; set; } = null!;

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
        public string UserId { get; set; } = null!;

        public bool IsActive { get; set; }

        [Required]
        public string ArtWorkId { get; set; } = null!;
    }
}
