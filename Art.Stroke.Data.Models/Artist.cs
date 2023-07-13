

namespace ArtStroke.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Artist;
    public class Artist
    {
        public Artist()
        {
            this.Id = Guid.NewGuid();

            this.CreatedWorks = new HashSet<ArtWork>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;


        [Required]
        [MaxLength(BiographyMaxLength)]
        public string Biography { get; set; } = null!;

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;

        public virtual ICollection<ArtWork> CreatedWorks { get; set; }
    }
}
