using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtStroke.Data.Migrations
{
    public partial class AddIsActiveColumnOnPrintDesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("927a45c2-ea60-46c9-81ae-bb9b256cbf02"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("a3c2aae9-6605-4e18-a03b-f4235577561a"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("d196b38a-01c5-4179-8c26-5d3066e36959"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("f7aad5fa-ed40-470f-8ead-2084eb907941"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PrintDesigns",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PrintDesigns");

            migrationBuilder.InsertData(
                table: "ArtWorks",
                columns: new[] { "Id", "ArtistId", "CreatedOn", "CreatingYear", "Height", "ImageUrl", "IsActive", "IsDesignedInPrint", "StyleId", "Technique", "Title", "Width" },
                values: new object[,]
                {
                    { new Guid("927a45c2-ea60-46c9-81ae-bb9b256cbf02"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/blue-boat-maria-arnaudova.jpg", false, false, 1, "Oil on canvas", "Single Boat", 35 },
                    { new Guid("a3c2aae9-6605-4e18-a03b-f4235577561a"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 350, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/sea-sunset-maria-arnaudova.jpg", false, false, 3, "Oil on canvas", "Sunset over the sea", 500 },
                    { new Guid("d196b38a-01c5-4179-8c26-5d3066e36959"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/swirling-of-life-maria-arnaudova.jpg", false, false, 4, "Aquarel", "Swirling", 35 },
                    { new Guid("f7aad5fa-ed40-470f-8ead-2084eb907941"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/split-pomegranate-maria-arnaudova.jpg", false, false, 2, "Acril on canvas", "Freshnest", 50 }
                });
        }
    }
}
