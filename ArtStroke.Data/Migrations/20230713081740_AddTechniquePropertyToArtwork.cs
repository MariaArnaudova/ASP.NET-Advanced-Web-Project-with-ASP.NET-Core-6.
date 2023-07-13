using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtStroke.Data.Migrations
{
    public partial class AddTechniquePropertyToArtwork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Technique",
                table: "ArtWorks",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Technique",
                table: "ArtWorks");
        }
    }
}
