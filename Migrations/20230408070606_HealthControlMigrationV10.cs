using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthControlApp.API.Migrations
{
    /// <inheritdoc />
    public partial class HealthControlMigrationV10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdGroup",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "SurName",
                table: "Employ",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "Employ",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdGroup",
                table: "Employ",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "Employ");

            migrationBuilder.DropColumn(
                name: "IdGroup",
                table: "Employ");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Employ",
                newName: "SurName");

            migrationBuilder.AddColumn<int>(
                name: "IdGroup",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
