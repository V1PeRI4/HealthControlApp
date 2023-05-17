using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthControlApp.API.Migrations
{
    /// <inheritdoc />
    public partial class HealthControlMigrationV24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Roles",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "HealthEmployStatuses",
                newName: "textHealthStatus");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Groups",
                newName: "group");

            migrationBuilder.AddColumn<string>(
                name: "fullName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fullName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "Roles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "textHealthStatus",
                table: "HealthEmployStatuses",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "group",
                table: "Groups",
                newName: "Name");
        }
    }
}
