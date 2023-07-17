using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtStroke.Data.Migrations
{
    public partial class AddIsActiveColumnInArtworkForSoftDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("3f65cdd0-ae9c-447f-a770-3714a93cc348"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("584ea8d0-b374-4bae-9a25-94298d3862f2"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("7145afc1-0c82-4515-8e61-302bb30be0f3"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("769b0026-1cc0-4d31-af9d-3bc400f4581f"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ArtWorks",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.InsertData(
                table: "ArtWorks",
                columns: new[] { "Id", "ArtistId", "CreatingYear", "Height", "ImageUrl", "IsDesignedInPrint", "StyleId", "Technique", "Title", "Width" },
                values: new object[,]
                {
                    { new Guid("016107a7-2489-47f7-b33e-c72f42662a15"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/blue-boat-maria-arnaudova.jpg", false, 1, "Oil on canvas", "Single Boat", 35 },
                    { new Guid("168889f6-54ec-429a-87e3-142154e954e7"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 350, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/sea-sunset-maria-arnaudova.jpg", false, 3, "Oil on canvas", "Sunset over the sea", 500 },
                    { new Guid("2eb8aaf4-9862-40b4-91f1-c8d407f4b37d"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/split-pomegranate-maria-arnaudova.jpg", false, 2, "Acril on canvas", "Freshnest", 50 },
                    { new Guid("39eb4ac7-5f93-4874-946c-7b19056595b7"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/swirling-of-life-maria-arnaudova.jpg", false, 4, "Aquarel", "Swirling", 35 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("016107a7-2489-47f7-b33e-c72f42662a15"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("168889f6-54ec-429a-87e3-142154e954e7"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("2eb8aaf4-9862-40b4-91f1-c8d407f4b37d"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("39eb4ac7-5f93-4874-946c-7b19056595b7"));

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ArtWorks");

            migrationBuilder.InsertData(
                table: "ArtWorks",
                columns: new[] { "Id", "ArtistId", "CreatedOn", "CreatingYear", "Height", "ImageUrl", "IsDesignedInPrint", "StyleId", "Technique", "Title", "Width" },
                values: new object[,]
                {
                    { new Guid("3f65cdd0-ae9c-447f-a770-3714a93cc348"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 350, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/sea-sunset-maria-arnaudova.jpg", false, 3, "Oil on canvas", "Sunset over the sea", 500 },
                    { new Guid("584ea8d0-b374-4bae-9a25-94298d3862f2"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/blue-boat-maria-arnaudova.jpg", false, 1, "Oil on canvas", "Single Boat", 35 },
                    { new Guid("7145afc1-0c82-4515-8e61-302bb30be0f3"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/swirling-of-life-maria-arnaudova.jpg", false, 4, "Aquarel", "Swirling", 35 },
                    { new Guid("769b0026-1cc0-4d31-af9d-3bc400f4581f"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/split-pomegranate-maria-arnaudova.jpg", false, 2, "Acril on canvas", "Freshnest", 50 }
                });
        }
    }
}
