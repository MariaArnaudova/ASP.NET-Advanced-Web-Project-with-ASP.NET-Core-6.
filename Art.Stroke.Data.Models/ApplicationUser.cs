
namespace ArtStroke.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();   
            this.PrintDesigns = new HashSet<PrintDesign>();
            this.TechniqueArts = new HashSet<NewTechniqueArt>();
        }

        public ICollection<PrintDesign> PrintDesigns { get; set; }

        public ICollection<NewTechniqueArt> TechniqueArts { get; set; }
    }
}
