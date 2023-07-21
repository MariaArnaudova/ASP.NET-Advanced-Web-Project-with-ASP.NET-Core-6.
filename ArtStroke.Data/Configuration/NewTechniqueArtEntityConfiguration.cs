namespace ArtStroke.Data.Configuration
{
    using ArtStroke.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    public class NewTechniqueArtEntityConfiguration : IEntityTypeConfiguration<NewTechniqueArt>
    {
        public void Configure(EntityTypeBuilder<NewTechniqueArt> builder)
        {
            builder.HasOne(nt => nt.User)
                 .WithMany(u => u.TechniqueArts)
                 .HasForeignKey(nt => nt.UserId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
