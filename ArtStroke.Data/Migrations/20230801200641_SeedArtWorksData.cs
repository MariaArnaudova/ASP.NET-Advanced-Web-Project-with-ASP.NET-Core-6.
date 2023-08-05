using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtStroke.Data.Migrations
{
    public partial class SeedArtWorksData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ArtWorks",
                columns: new[] { "Id", "ArtistId", "CreatingYear", "Height", "ImageUrl", "IsDesignedInPrint", "StyleId", "Technique", "Title", "Width" },
                values: new object[,]
                {
                    { new Guid("386f6b6a-5e57-438b-bf8e-9ae5a93abb78"), new Guid("4db15f1b-f1c7-4cda-a6fc-a8f1dc4c4d2b"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/sea-sunset-maria-arnaudova.jpg", false, 3, "Oil on canvas", "Sunset over the sea", 50 },
                    { new Guid("d3d27c28-2468-46f2-9df0-bc841d7d8392"), new Guid("4db15f1b-f1c7-4cda-a6fc-a8f1dc4c4d2b"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/split-pomegranate-maria-arnaudova.jpg", false, 2, "Acril on canvas", "Freshnest", 50 },
                    { new Guid("ef5a8311-c61a-463c-8a24-78f2c503f531"), new Guid("4db15f1b-f1c7-4cda-a6fc-a8f1dc4c4d2b"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/swirling-of-life-maria-arnaudova.jpg", false, 4, "Aquarel", "Swirling", 35 },
                    { new Guid("fc7aebcf-b8b8-44a0-a460-2ab3ab806ae4"), new Guid("4db15f1b-f1c7-4cda-a6fc-a8f1dc4c4d2b"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/blue-boat-maria-arnaudova.jpg", false, 1, "Oil on canvas", "Single Boat", 35 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("386f6b6a-5e57-438b-bf8e-9ae5a93abb78"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("d3d27c28-2468-46f2-9df0-bc841d7d8392"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("ef5a8311-c61a-463c-8a24-78f2c503f531"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("fc7aebcf-b8b8-44a0-a460-2ab3ab806ae4"));
        }
    }
}
