using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotographyApp.Migrations
{
    /// <inheritdoc />
    public partial class AddImagePathsToPackages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePaths",
                table: "Packages",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePaths",
                table: "Packages");
        }
    }
}
