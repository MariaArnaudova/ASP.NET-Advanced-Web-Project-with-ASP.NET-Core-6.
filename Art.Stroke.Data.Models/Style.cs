
namespace ArtStroke.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Style;
    public class Style
    {
        public Style()
        {
            this.ArtWorks = new HashSet<ArtWork>(); 
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<ArtWork> ArtWorks { get; set; }
    }

}
