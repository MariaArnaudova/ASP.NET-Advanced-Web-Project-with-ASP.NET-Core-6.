using ArtStroke.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
namespace ArtStroke.Data.Configuration
{
    public class NewTechniqueArtEntityConfiguration : IEntityTypeConfiguration<NewTechiqueArt>
    {
        public void Configure(EntityTypeBuilder<NewTechiqueArt> builder)
        {
           builder.HasOne(nt => nt.User)
                .WithMany(u => u.NewTechiqueArts)
                .HasForeignKey(nt => nt.UserId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
