
namespace ArtStroke.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;
    using static Common.EntityValidationConstants.User;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();   
            this.PrintDesigns = new HashSet<PrintDesign>();
            this.TechniqueArts = new HashSet<NewTechniqueArt>();
        }

        //[Required]
        //[MaxLength(FirstNameMaxLength)]
        //public string FirstName { get; set; } = null!;

        //[Required]
        //[MaxLength(LastNameMaxLength)]
        //public string LastName { get; set; } = null!;

        public ICollection<PrintDesign> PrintDesigns { get; set; }

        public ICollection<NewTechniqueArt> TechniqueArts { get; set; }
    }
}
