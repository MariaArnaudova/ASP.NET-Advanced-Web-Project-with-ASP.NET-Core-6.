

namespace ArtStroke.Data
{
    using ArtStroke.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class ArtStrokeDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ArtStrokeDbContext(DbContextOptions<ArtStrokeDbContext> options)
            : base(options)
        {
            if (!this.Database.IsRelational())
            {
                this.Database.EnsureCreated();  
            }
        }

        public DbSet<Artist> Artists { get; set; } = null!;
        public DbSet<ArtWork> ArtWorks { get; set; } = null!;
        public DbSet<Style> Styles { get; set; } = null!;
        public DbSet<ArtEvent> ArtEvents { get; set; } = null!;
        public DbSet<PrintDesign> PrintDesigns { get; set; } = null!;
        public DbSet<NewTechniqueArt> NewTechiqueArts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(ArtStrokeDbContext)) ??
                Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);
            base.OnModelCreating(builder);  
        }
    }
}