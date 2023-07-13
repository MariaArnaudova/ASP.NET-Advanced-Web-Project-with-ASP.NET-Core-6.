
namespace ArtStroke.Data.Configuration
{
    using ArtStroke.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StyleEntityConfiguration : IEntityTypeConfiguration<Style>
    {
        public void Configure(EntityTypeBuilder<Style> builder)
        {

            builder.HasData(this.GenerateSyles());
        }

        private Style[] GenerateSyles()
        {
            ICollection<Style> styles = new HashSet<Style>();

            Style style;

            style = new Style()
            {
                Id = 1,
                Name = "Classic"
            };
            styles.Add(style);


            style = new Style()
            {
                Id = 2,
                Name = "Modern"
            };
            styles.Add(style);

            style = new Style()
            {
                Id = 3,
                Name = "Expressionism"
            };
            styles.Add(style);

            style = new Style()
            {
                Id = 4,
                Name = "Abstract"
            };
            styles.Add(style);

            return styles.ToArray();
        }
    }
}
