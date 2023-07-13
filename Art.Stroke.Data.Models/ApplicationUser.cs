
namespace ArtStroke.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();   
            this.PrintDesigns = new HashSet<PrintDesign>();
            this.NewTechiqueArts = new HashSet<NewTechiqueArt>();
        }

        public ICollection<PrintDesign> PrintDesigns { get; set; }

        public ICollection<NewTechiqueArt> NewTechiqueArts { get; set; }
    }
}
