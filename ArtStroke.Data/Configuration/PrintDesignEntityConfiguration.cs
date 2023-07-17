
namespace ArtStroke.Data.Configuration
{
    using ArtStroke.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Globalization;

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

            builder
                .Property(h => h.IsActive)
                .HasDefaultValue(true);

            //builder.HasData(this.GeneratePrintDesign());
        }

        //private PrintDesign[] GeneratePrintDesign()
        //{
        //    ICollection<PrintDesign> printDesigns = new HashSet<PrintDesign>();

        //    PrintDesign printDesign;

        //    printDesign = new PrintDesign()
        //    {
        //        Id = 1,
        //        Title = "Together",
        //        Width = 25,
        //        Height = 25,
        //        ImageUrl = "https://render.fineartamerica.com/images/rendered/wall-view/medium/room001/acrylic-print/images/artworkimages/medium/1/together-maria-arnaudova.jpg?printWidth=8&printHeight=8&finishId=hangingwire",
        //        CreatorName = "Pepi",
        //        Description = "Modern and fresh decorating",
        //        UserId = Guid.Parse("B2BF1184-07BA-4A45-89D5-522B509F80DE"),
        //        ArtWorkId = Guid.Parse("6AB84C81-3D1C-4EB4-9C54-E9E3508742D7")
        //    };
        //    printDesigns.Add(printDesign);

        //    printDesign = new PrintDesign()
        //    {
        //        Id = 2,
        //        Title = "Freshnest",
        //        Width = 70,
        //        Height = 70,
        //        ImageUrl = "https://render.fineartamerica.com/images/rendered/wall-view/medium/room002/acrylic-print/images/artworkimages/medium/1/split-pomegranate-maria-arnaudova.jpg?printWidth=30&printHeight=30&finishId=hangingwire",
        //        CreatorName = "Pepi",
        //        Description = "Contemporary interior and decorating",
        //        UserId = Guid.Parse("B2BF1184-07BA-4A45-89D5-522B509F80DE"),
        //        ArtWorkId = Guid.Parse("F7AAD5FA-ED40-470F-8EAD-2084EB907941")
        //    };
        //    printDesigns.Add(printDesign);

        //    printDesign = new PrintDesign()
        //    {
        //        Id = 3,
        //        Title = "Single Boat",
        //        Width = 120,
        //        Height = 80,
        //        ImageUrl = "https://render.fineartamerica.com/images/rendered/wall-view/medium/room003/acrylic-print/images/artworkimages/medium/1/blue-boat-maria-arnaudova.jpg?printWidth=40&printHeight=32&finishId=hangingwire",
        //        CreatorName = "Pepi",
        //        Description = "Contemporary interior and decorating",
        //        UserId = Guid.Parse("B2BF1184-07BA-4A45-89D5-522B509F80DE"),
        //        ArtWorkId = Guid.Parse("927A45C2-EA60-46C9-81AE-BB9B256CBF02")
        //    };

        //    printDesigns.Add(printDesign);

        //    return printDesigns.ToArray();
        //}
    }
}
