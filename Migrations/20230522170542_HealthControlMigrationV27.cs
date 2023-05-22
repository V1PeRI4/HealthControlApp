using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthControlApp.API.Migrations
{
    /// <inheritdoc />
    public partial class HealthControlMigrationV27 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageName",
                table: "Users");
        }
    }
}
