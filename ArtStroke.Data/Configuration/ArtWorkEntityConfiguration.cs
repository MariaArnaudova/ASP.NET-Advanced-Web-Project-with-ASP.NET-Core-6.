
namespace ArtStroke.Data.Configuration
{
    using ArtStroke.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    public class ArtWorkEntityConfiguration : IEntityTypeConfiguration<ArtWork>
    {
        public void Configure(EntityTypeBuilder<ArtWork> builder)
        {
            builder.Property(aw => aw.CreatedOn)
                .HasDefaultValue(DateTime.UtcNow);

            builder.HasOne(aw => aw.Artist)
                 .WithMany(a => a.CreatedWorks)
                 .HasForeignKey(aw => aw.ArtistId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(aw => aw.Style)
                .WithMany(s => s.ArtWorks)
                .HasForeignKey(aw => aw.StyleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GenerateArtWorks());
        }

        private ArtWork[] GenerateArtWorks()
        {
            ICollection<ArtWork> artWorks = new HashSet<ArtWork>();

            ArtWork artWork;
            string yearString = "2022";
            DateTime creatingYear;
            DateTime.TryParseExact(yearString, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out creatingYear);
            
            artWork = new ArtWork()
            {
                Title = "Wooden Brige",
                Technique = "Oil on canvas",
                StyleId = 1,
                Width = 1000,
                Height = 700,
                ImageUrl = "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/blue-boat-maria-arnaudova.jpg",
                CreatingYear = creatingYear,
                ArtistId = Guid.Parse("9ACB423B-F83D-4A6F-A4E3-D28271E0E828")
            };
            artWorks.Add(artWork);

            artWork = new ArtWork()
            {
                Title = "Single Boat",
                Technique = "Acril on canvas",
                StyleId = 2,
                Width = 250,
                Height = 180,
                ImageUrl = "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/split-pomegranate-maria-arnaudova.jpg",
                CreatingYear = creatingYear,
                ArtistId = Guid.Parse("9ACB423B-F83D-4A6F-A4E3-D28271E0E828")
            };
            artWorks.Add(artWork);

            artWork = new ArtWork()
            {
                Title = "Sunset over the sea",
                Technique = "Oil on canvas",
                StyleId = 3,
                Width = 500,
                Height = 350,
                ImageUrl = "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/sea-sunset-maria-arnaudova.jpg",
                CreatingYear = creatingYear,
                ArtistId = Guid.Parse("9ACB423B-F83D-4A6F-A4E3-D28271E0E828")
            };
            artWorks.Add(artWork);

            artWork = new ArtWork()
            {
                Title = "Swirling",
                Technique = "Aquarel",
                StyleId = 4,
                Width = 180,
                Height = 250,
                ImageUrl = "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/swirling-of-life-maria-arnaudova.jpg",
                CreatingYear = creatingYear,
                ArtistId = Guid.Parse("9ACB423B-F83D-4A6F-A4E3-D28271E0E828")
            };
            artWorks.Add(artWork);

            return artWorks.ToArray();
        }
    }
}
