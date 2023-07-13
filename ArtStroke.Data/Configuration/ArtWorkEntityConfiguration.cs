
namespace ArtStroke.Data.Configuration
{
    using ArtStroke.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class ArtWorkEntityConfiguration : IEntityTypeConfiguration<ArtWork>
    {
        public void Configure(EntityTypeBuilder<ArtWork> builder)
        {
            builder.HasOne(aw => aw.Artist)
                 .WithMany(a => a.CreatedWorks)
                 .HasForeignKey(aw => aw.ArtistId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(aw => aw.Style)
                .WithMany(s => s.ArtWorks)
                .HasForeignKey(aw => aw.StyleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
