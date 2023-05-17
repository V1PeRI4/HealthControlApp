using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthControlApp.API.Migrations
{
    /// <inheritdoc />
    public partial class HealthControlMigrationV25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fullName",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fullName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
