using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtStroke.Data.Migrations
{
    public partial class SeedArtWorkDataSecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ArtWorks",
                columns: new[] { "Id", "ArtistId", "CreatingYear", "Height", "ImageUrl", "IsDesignedInPrint", "StyleId", "Technique", "Title", "Width" },
                values: new object[,]
                {
                    { new Guid("605ec1df-b6a8-4b8d-97bf-199b904894f4"), new Guid("4db15f1b-f1c7-4cda-a6fc-a8f1dc4c4d2b"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/blue-boat-maria-arnaudova.jpg", false, 1, "Oil on canvas", "Single Boat", 35 },
                    { new Guid("82d6c357-5443-4041-8687-a08e1641fe1a"), new Guid("4db15f1b-f1c7-4cda-a6fc-a8f1dc4c4d2b"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/sea-sunset-maria-arnaudova.jpg", false, 3, "Oil on canvas", "Sunset over the sea", 50 },
                    { new Guid("a70fe6a7-e9ed-4422-839a-38555cc32596"), new Guid("4db15f1b-f1c7-4cda-a6fc-a8f1dc4c4d2b"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/split-pomegranate-maria-arnaudova.jpg", false, 2, "Acril on canvas", "Freshnest", 50 },
                    { new Guid("df50606e-acea-4e2e-a2d1-9af8e5cc5f1e"), new Guid("4db15f1b-f1c7-4cda-a6fc-a8f1dc4c4d2b"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/swirling-of-life-maria-arnaudova.jpg", false, 4, "Aquarel", "Swirling", 35 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("605ec1df-b6a8-4b8d-97bf-199b904894f4"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("82d6c357-5443-4041-8687-a08e1641fe1a"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("a70fe6a7-e9ed-4422-839a-38555cc32596"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("df50606e-acea-4e2e-a2d1-9af8e5cc5f1e"));
        }
    }
}
