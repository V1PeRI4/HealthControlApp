using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthControlApp.API.Migrations
{
    /// <inheritdoc />
    public partial class HealthControlMigrationV16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pass",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pass",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
