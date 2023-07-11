

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
    }
}