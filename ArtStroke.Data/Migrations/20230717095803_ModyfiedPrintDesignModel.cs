using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtStroke.Data.Migrations
{
    public partial class ModyfiedPrintDesignModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PrintDesigns",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "PrintDesigns",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "PrintDesigns",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "ArtWorks",
                columns: new[] { "Id", "ArtistId", "CreatingYear", "Height", "ImageUrl", "IsDesignedInPrint", "StyleId", "Technique", "Title", "Width" },
                values: new object[,]
                {
                    { new Guid("40ae2481-7265-4a52-a8b3-bc6d52b5e356"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 350, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/sea-sunset-maria-arnaudova.jpg", false, 3, "Oil on canvas", "Sunset over the sea", 500 },
                    { new Guid("5040d817-c417-45c1-b5df-28909c00c175"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/blue-boat-maria-arnaudova.jpg", false, 1, "Oil on canvas", "Single Boat", 35 },
                    { new Guid("9ef908d0-75d7-49f6-8ea2-8235ec06ecc3"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/swirling-of-life-maria-arnaudova.jpg", false, 4, "Aquarel", "Swirling", 35 },
                    { new Guid("d361c908-a5af-48d3-ab52-5bceda2e0702"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/split-pomegranate-maria-arnaudova.jpg", false, 2, "Acril on canvas", "Freshnest", 50 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("40ae2481-7265-4a52-a8b3-bc6d52b5e356"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("5040d817-c417-45c1-b5df-28909c00c175"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("9ef908d0-75d7-49f6-8ea2-8235ec06ecc3"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("d361c908-a5af-48d3-ab52-5bceda2e0702"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PrintDesigns");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "PrintDesigns");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "PrintDesigns");

            migrationBuilder.InsertData(
                table: "ArtWorks",
                columns: new[] { "Id", "ArtistId", "CreatedOn", "CreatingYear", "Height", "ImageUrl", "IsActive", "IsDesignedInPrint", "StyleId", "Technique", "Title", "Width" },
                values: new object[,]
                {
                    { new Guid("016107a7-2489-47f7-b33e-c72f42662a15"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/blue-boat-maria-arnaudova.jpg", false, false, 1, "Oil on canvas", "Single Boat", 35 },
                    { new Guid("168889f6-54ec-429a-87e3-142154e954e7"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 350, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/sea-sunset-maria-arnaudova.jpg", false, false, 3, "Oil on canvas", "Sunset over the sea", 500 },
                    { new Guid("2eb8aaf4-9862-40b4-91f1-c8d407f4b37d"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/split-pomegranate-maria-arnaudova.jpg", false, false, 2, "Acril on canvas", "Freshnest", 50 },
                    { new Guid("39eb4ac7-5f93-4874-946c-7b19056595b7"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/swirling-of-life-maria-arnaudova.jpg", false, false, 4, "Aquarel", "Swirling", 35 }
                });
        }
    }
}
