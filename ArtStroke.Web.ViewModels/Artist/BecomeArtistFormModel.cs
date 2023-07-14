

namespace ArtStroke.Web.ViewModels.Artist
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Artist;
    public class BecomeArtistFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        [Display(Name = "Artist Name")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(BiographyMaxLength, MinimumLength = BiographyMinLength)]
        public string Biography { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Phone]
        [Display(Name="Phone")]
        public string PhoneNumber { get; set; } = null!;

    }
}
