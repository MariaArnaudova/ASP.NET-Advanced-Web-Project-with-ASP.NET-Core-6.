

namespace ArtStroke.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Artist
    {
        public Artist()
        {
            this.Id = Guid.NewGuid();

            this.ArtWorks = new HashSet<ArtWork>();
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Biography { get; set; } = null!;

        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;

        public ICollection<ArtWork> ArtWorks { get; set; }
    }
}
