using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthControlApp.API.Migrations
{
    /// <inheritdoc />
    public partial class HealthControlMigrationV19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdHealthEmployStatus",
                table: "Users",
                newName: "IdHealthStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdHealthStatus",
                table: "Users",
                newName: "IdHealthEmployStatus");
        }
    }
}
