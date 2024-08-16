using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotographyApp.Migrations
{
    /// <inheritdoc />
    public partial class RemovePhotographerFromPackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Users_PhotographerId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_PhotographerId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "PhotographerId",
                table: "Packages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhotographerId",
                table: "Packages",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_PhotographerId",
                table: "Packages",
                column: "PhotographerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Users_PhotographerId",
                table: "Packages",
                column: "PhotographerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
