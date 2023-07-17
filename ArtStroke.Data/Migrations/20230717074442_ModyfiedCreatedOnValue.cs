using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtStroke.Data.Migrations
{
    public partial class ModyfiedCreatedOnValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ArtWorks",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 16, 9, 10, 45, 128, DateTimeKind.Utc).AddTicks(2701));

            migrationBuilder.InsertData(
                table: "ArtWorks",
                columns: new[] { "Id", "ArtistId", "CreatingYear", "Height", "ImageUrl", "IsDesignedInPrint", "StyleId", "Technique", "Title", "Width" },
                values: new object[,]
                {
                    { new Guid("3f65cdd0-ae9c-447f-a770-3714a93cc348"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 350, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/sea-sunset-maria-arnaudova.jpg", false, 3, "Oil on canvas", "Sunset over the sea", 500 },
                    { new Guid("584ea8d0-b374-4bae-9a25-94298d3862f2"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/blue-boat-maria-arnaudova.jpg", false, 1, "Oil on canvas", "Single Boat", 35 },
                    { new Guid("7145afc1-0c82-4515-8e61-302bb30be0f3"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/swirling-of-life-maria-arnaudova.jpg", false, 4, "Aquarel", "Swirling", 35 },
                    { new Guid("769b0026-1cc0-4d31-af9d-3bc400f4581f"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/split-pomegranate-maria-arnaudova.jpg", false, 2, "Acril on canvas", "Freshnest", 50 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ArtWorks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 16, 9, 10, 45, 128, DateTimeKind.Utc).AddTicks(2701),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.InsertData(
                table: "ArtWorks",
                columns: new[] { "Id", "ArtistId", "CreatedOn", "CreatingYear", "Height", "ImageUrl", "IsDesignedInPrint", "StyleId", "Technique", "Title", "Width" },
                values: new object[,]
                {
                    { new Guid("17f53daf-a9d8-4491-a87c-efd6edcae010"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 250, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/swirling-of-life-maria-arnaudova.jpg", false, 4, "Aquarel", "Swirling", 180 },
                    { new Guid("74a4676d-7cd7-4ca8-ab4f-155944552bd7"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 700, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/blue-boat-maria-arnaudova.jpg", false, 1, "Oil on canvas", "Single Boat", 1000 },
                    { new Guid("96e00100-3dad-41c4-9476-c51c58583fcd"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 180, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/split-pomegranate-maria-arnaudova.jpg", false, 2, "Acril on canvas", "Freshnest", 250 },
                    { new Guid("c06d9494-9434-4a5a-a56a-adcc5ace698f"), new Guid("9acb423b-f83d-4a6f-a4e3-d28271e0e828"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 350, "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/sea-sunset-maria-arnaudova.jpg", false, 3, "Oil on canvas", "Sunset over the sea", 500 }
                });
        }
    }
}
