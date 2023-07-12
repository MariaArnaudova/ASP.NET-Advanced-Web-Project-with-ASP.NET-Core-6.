

namespace ArtStroke.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Artist;
    public class Artist
    {
        public Artist()
        {
            this.Id = Guid.NewGuid();

            this.ArtWorks = new HashSet<ArtWork>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;


        [Required]
        [MaxLength(BiographyMaxLength)]
        public string Biography { get; set; } = null!;

        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;

        public ICollection<ArtWork> ArtWorks { get; set; }
    }
}
