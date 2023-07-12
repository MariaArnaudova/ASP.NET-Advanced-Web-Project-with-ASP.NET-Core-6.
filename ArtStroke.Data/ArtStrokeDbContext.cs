

namespace ArtStroke.Data
{
    using ArtStroke.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class ArtStrokeDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ArtStrokeDbContext(DbContextOptions<ArtStrokeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; } = null!;
        public DbSet<ArtWork> ArtWorks { get; set; } = null!;
        public DbSet<Style> Styles { get; set; } = null!;
        public DbSet<ArtEvent> ArtEvents { get; set; } = null!;
        public DbSet<PrintDesign> PrintDesigns { get; set; } = null!;
        public DbSet<NewTechiqueArt> NewTechiqueArts { get; set; } = null!;
    }
}