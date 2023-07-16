using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtStroke.Data.Migrations
{
    public partial class AddedIsDesignedInPrintColumnInArtWorkModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("25d59a82-249d-425c-b404-6e4bcc419944"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("428a9d87-269e-4b07-82f9-6dd74b9063af"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("a37309b4-4a19-4a5f-8347-706562ff6cdd"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("af938ebb-d748-48a7-b6f4-8cbe11621190"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ArtWorks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 9, 10, 45, 128, DateTimeKind.Utc).AddTicks(2701),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 13, 10, 15, 31, 743, DateTimeKind.Utc).AddTicks(1572));

            migrationBuilder.AddColumn<bool>(
                name: "IsDesignedInPrint",
                table: "ArtWorks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "ArtWorks",
                columns: new[] { "Id", "ArtistId", "CreatingYear", "Height", "ImageUrl", "IsDesignedInPrint", "StyleId", "Technique", "Title", "Width" },
                values: new object[,]
                {
                    { new Guid("17f53daf-a9d8-4491-a87c-efd6edcae010"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 250, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/swirling-of-life-maria-arnaudova.jpg", false, 4, "Aquarel", "Swirling", 180 },
                    { new Guid("74a4676d-7cd7-4ca8-ab4f-155944552bd7"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 700, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/blue-boat-maria-arnaudova.jpg", false, 1, "Oil on canvas", "Single Boat", 1000 },
                    { new Guid("96e00100-3dad-41c4-9476-c51c58583fcd"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 180, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/split-pomegranate-maria-arnaudova.jpg", false, 2, "Acril on canvas", "Freshnest", 250 },
                    { new Guid("c06d9494-9434-4a5a-a56a-adcc5ace698f"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 350, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/sea-sunset-maria-arnaudova.jpg", false, 3, "Oil on canvas", "Sunset over the sea", 500 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("17f53daf-a9d8-4491-a87c-efd6edcae010"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("74a4676d-7cd7-4ca8-ab4f-155944552bd7"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("96e00100-3dad-41c4-9476-c51c58583fcd"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("c06d9494-9434-4a5a-a56a-adcc5ace698f"));

            migrationBuilder.DropColumn(
                name: "IsDesignedInPrint",
                table: "ArtWorks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ArtWorks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 13, 10, 15, 31, 743, DateTimeKind.Utc).AddTicks(1572),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 9, 10, 45, 128, DateTimeKind.Utc).AddTicks(2701));

            migrationBuilder.InsertData(
                table: "ArtWorks",
                columns: new[] { "Id", "ArtistId", "CreatedOn", "CreatingYear", "Height", "ImageUrl", "StyleId", "Technique", "Title", "Width" },
                values: new object[,]
                {
                    { new Guid("25d59a82-249d-425c-b404-6e4bcc419944"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 180, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/split-pomegranate-maria-arnaudova.jpg", 2, "Acril on canvas", "Single Boat", 250 },
                    { new Guid("428a9d87-269e-4b07-82f9-6dd74b9063af"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 350, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/sea-sunset-maria-arnaudova.jpg", 3, "Oil on canvas", "Sunset over the sea", 500 },
                    { new Guid("a37309b4-4a19-4a5f-8347-706562ff6cdd"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 700, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/blue-boat-maria-arnaudova.jpg", 1, "Oil on canvas", "Wooden Brige", 1000 },
                    { new Guid("af938ebb-d748-48a7-b6f4-8cbe11621190"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 250, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/swirling-of-life-maria-arnaudova.jpg", 4, "Aquarel", "Swirling", 180 }
                });
        }
    }
}
