
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
                .HasDefaultValueSql("GETDATE()");

            builder.Property(aw => aw.IsActive)
                .HasDefaultValue(true);

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
                Title = "Together",
                Technique = "Acryl on canvas",
                StyleId = 5,
                Width = 25,
                Height = 25,
                ImageUrl = "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/together-maria-arnaudova.jpg",
                CreatingYear = creatingYear,
                ArtistId = Guid.Parse("4DB15F1B-F1C7-4CDA-A6FC-A8F1DC4C4D2B")
            };

            artWork = new ArtWork()
            {
                Title = "Single Boat",
                Technique = "Oil on canvas",
                StyleId = 1,
                Width = 35,
                Height = 25,
                ImageUrl = "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/blue-boat-maria-arnaudova.jpg",
                CreatingYear = creatingYear,
                ArtistId = Guid.Parse("4DB15F1B-F1C7-4CDA-A6FC-A8F1DC4C4D2B")
            };
            artWorks.Add(artWork);

            artWork = new ArtWork()
            {
                Title = "Freshnest",
                Technique = "Acril on canvas",
                StyleId = 2,
                Width = 50,
                Height = 50,
                ImageUrl = "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/split-pomegranate-maria-arnaudova.jpg",
                CreatingYear = creatingYear,
                ArtistId = Guid.Parse("4DB15F1B-F1C7-4CDA-A6FC-A8F1DC4C4D2B")
            };
            artWorks.Add(artWork);

            artWork = new ArtWork()
            {
                Title = "Sunset over the sea",
                Technique = "Oil on canvas",
                StyleId = 3,
                Width = 50,
                Height = 35,
                ImageUrl = "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/sea-sunset-maria-arnaudova.jpg",
                CreatingYear = creatingYear,
                ArtistId = Guid.Parse("4DB15F1B-F1C7-4CDA-A6FC-A8F1DC4C4D2B")
            };
            artWorks.Add(artWork);

            artWork = new ArtWork()
            {
                Title = "Swirling",
                Technique = "Aquarel",
                StyleId = 4,
                Width = 35,
                Height = 50,
                ImageUrl = "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/swirling-of-life-maria-arnaudova.jpg",
                CreatingYear = creatingYear,
                ArtistId = Guid.Parse("4DB15F1B-F1C7-4CDA-A6FC-A8F1DC4C4D2B")
            };
            artWorks.Add(artWork);

            return artWorks.ToArray();
        }
    }
}
