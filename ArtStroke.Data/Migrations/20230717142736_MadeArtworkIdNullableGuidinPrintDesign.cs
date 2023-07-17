using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtStroke.Data.Migrations
{
    public partial class MadeArtworkIdNullableGuidinPrintDesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtWorkId",
                table: "PrintDesigns",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "ArtWorks",
                columns: new[] { "Id", "ArtistId", "CreatingYear", "Height", "ImageUrl", "IsDesignedInPrint", "StyleId", "Technique", "Title", "Width" },
                values: new object[,]
                {
                    { new Guid("a8ab17a9-e106-4174-97a9-d88d9179a035"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 350, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/sea-sunset-maria-arnaudova.jpg", false, 3, "Oil on canvas", "Sunset over the sea", 500 },
                    { new Guid("b7cabf9c-6c17-4300-8259-b058bcdbb165"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/blue-boat-maria-arnaudova.jpg", false, 1, "Oil on canvas", "Single Boat", 35 },
                    { new Guid("e022ae31-1b2d-4439-964b-d0e22908aad5"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/swirling-of-life-maria-arnaudova.jpg", false, 4, "Aquarel", "Swirling", 35 },
                    { new Guid("e20af2d9-c04c-44c8-b683-9c9b0ce4e82a"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/split-pomegranate-maria-arnaudova.jpg", false, 2, "Acril on canvas", "Freshnest", 50 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("a8ab17a9-e106-4174-97a9-d88d9179a035"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("b7cabf9c-6c17-4300-8259-b058bcdbb165"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("e022ae31-1b2d-4439-964b-d0e22908aad5"));

            migrationBuilder.DeleteData(
                table: "ArtWorks",
                keyColumn: "Id",
                keyValue: new Guid("e20af2d9-c04c-44c8-b683-9c9b0ce4e82a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtWorkId",
                table: "PrintDesigns",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "ArtWorks",
                columns: new[] { "Id", "ArtistId", "CreatedOn", "CreatingYear", "Height", "ImageUrl", "IsActive", "IsDesignedInPrint", "StyleId", "Technique", "Title", "Width" },
                values: new object[,]
                {
                    { new Guid("40ae2481-7265-4a52-a8b3-bc6d52b5e356"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 350, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/sea-sunset-maria-arnaudova.jpg", false, false, 3, "Oil on canvas", "Sunset over the sea", 500 },
                    { new Guid("5040d817-c417-45c1-b5df-28909c00c175"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/blue-boat-maria-arnaudova.jpg", false, false, 1, "Oil on canvas", "Single Boat", 35 },
                    { new Guid("9ef908d0-75d7-49f6-8ea2-8235ec06ecc3"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/swirling-of-life-maria-arnaudova.jpg", false, false, 4, "Aquarel", "Swirling", 35 },
                    { new Guid("d361c908-a5af-48d3-ab52-5bceda2e0702"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/split-pomegranate-maria-arnaudova.jpg", false, false, 2, "Acril on canvas", "Freshnest", 50 }
                });
        }
    }
}
