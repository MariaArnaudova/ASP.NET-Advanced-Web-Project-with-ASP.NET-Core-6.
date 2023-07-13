using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtStroke.Data.Migrations
{
    public partial class AddCreatedOnColumnToArtWorks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("31f49e3d-93fc-4844-af54-4654d0443ab5"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("3bd417c9-7399-45f2-8e17-ff21ed7adb78"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("6c7b8c19-eb1e-4a15-aea4-4c02dc622578"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("96668c84-47cb-4fcb-b6d5-d439d59aa81f"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ArtWorks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 13, 10, 15, 31, 743, DateTimeKind.Utc).AddTicks(1572));

            migrationBuilder.InsertData(
                table: "ArtWorks",
                columns: new[] { "Id", "ArtistId", "CreatingYear", "Height", "ImageUrl", "StyleId", "Technique", "Title", "Width" },
                values: new object[,]
                {
                    { new Guid("25d59a82-249d-425c-b404-6e4bcc419944"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 180, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/split-pomegranate-maria-arnaudova.jpg", 2, "Acril on canvas", "Single Boat", 250 },
                    { new Guid("428a9d87-269e-4b07-82f9-6dd74b9063af"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 350, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/sea-sunset-maria-arnaudova.jpg", 3, "Oil on canvas", "Sunset over the sea", 500 },
                    { new Guid("a37309b4-4a19-4a5f-8347-706562ff6cdd"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 700, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/blue-boat-maria-arnaudova.jpg", 1, "Oil on canvas", "Wooden Brige", 1000 },
                    { new Guid("af938ebb-d748-48a7-b6f4-8cbe11621190"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 250, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/swirling-of-life-maria-arnaudova.jpg", 4, "Aquarel", "Swirling", 180 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ArtWorks");

            migrationBuilder.InsertData(
                table: "ArtWorks",
                columns: new[] { "Id", "ArtistId", "CreatingYear", "Height", "ImageUrl", "StyleId", "Technique", "Title", "Width" },
                values: new object[,]
                {
                    { new Guid("31f49e3d-93fc-4844-af54-4654d0443ab5"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 700, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/blue-boat-maria-arnaudova.jpg", 1, "Oil on canvas", "Wooden Brige", 1000 },
                    { new Guid("3bd417c9-7399-45f2-8e17-ff21ed7adb78"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 250, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/swirling-of-life-maria-arnaudova.jpg", 4, "Aquarel", "Swirling", 180 },
                    { new Guid("6c7b8c19-eb1e-4a15-aea4-4c02dc622578"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 350, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/sea-sunset-maria-arnaudova.jpg", 3, "Oil on canvas", "Sunset over the sea", 500 },
                    { new Guid("96668c84-47cb-4fcb-b6d5-d439d59aa81f"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 180, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/split-pomegranate-maria-arnaudova.jpg", 2, "Acril on canvas", "Single Boat", 250 }
                });
        }
    }
}
