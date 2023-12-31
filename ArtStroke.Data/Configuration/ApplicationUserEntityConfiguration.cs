﻿
namespace ArtStroke.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ArtStroke.Data.Models;
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.FirstName)
                .HasDefaultValue("Test");


            builder.Property(u => u.LastName)
                .HasDefaultValue("TestovUser");
        }
    }
}
