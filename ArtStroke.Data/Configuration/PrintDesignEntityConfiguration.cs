
namespace ArtStroke.Data.Configuration
{
    using ArtStroke.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class PrintDesignEntityConfiguration : IEntityTypeConfiguration<PrintDesign>
    {
        public void Configure(EntityTypeBuilder<PrintDesign> builder)
        {
            builder.HasOne(pd => pd.ArtWork)
                .WithMany(aw => aw.PrintDesigns)
                .HasForeignKey(pd => pd.ArtWorkId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pd => pd.User)
                .WithMany(u => u.PrintDesigns)
                .HasForeignKey(pd => pd.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
