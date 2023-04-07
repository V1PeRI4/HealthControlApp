using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthControlApp.API.Migrations
{
    /// <inheritdoc />
    public partial class HealthControlMigrationV5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employ_HealthEmployStatuses_HealthEmployStatusId",
                table: "Employ");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_MainGroups_MainGroupId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Employ_EmployId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_GroupId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EmployId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_GroupId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Groups_MainGroupId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Employ_HealthEmployStatusId",
                table: "Employ");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Users",
                newName: "IdRole");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Users",
                newName: "IdGroup");

            migrationBuilder.RenameColumn(
                name: "EmployId",
                table: "Users",
                newName: "IdEmploy");

            migrationBuilder.RenameColumn(
                name: "HealthStatus",
                table: "HealthEmployStatuses",
                newName: "IdHealthStatus");

            migrationBuilder.RenameColumn(
                name: "MainGroupId",
                table: "Groups",
                newName: "IdMainGroup");

            migrationBuilder.RenameColumn(
                name: "HealthEmployStatusId",
                table: "Employ",
                newName: "IdHealthEmployStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdRole",
                table: "Users",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "IdGroup",
                table: "Users",
                newName: "GroupId");

            migrationBuilder.RenameColumn(
                name: "IdEmploy",
                table: "Users",
                newName: "EmployId");

            migrationBuilder.RenameColumn(
                name: "IdHealthStatus",
                table: "HealthEmployStatuses",
                newName: "HealthStatus");

            migrationBuilder.RenameColumn(
                name: "IdMainGroup",
                table: "Groups",
                newName: "MainGroupId");

            migrationBuilder.RenameColumn(
                name: "IdHealthEmployStatus",
                table: "Employ",
                newName: "HealthEmployStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployId",
                table: "Users",
                column: "EmployId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupId",
                table: "Users",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_MainGroupId",
                table: "Groups",
                column: "MainGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Employ_HealthEmployStatusId",
                table: "Employ",
                column: "HealthEmployStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employ_HealthEmployStatuses_HealthEmployStatusId",
                table: "Employ",
                column: "HealthEmployStatusId",
                principalTable: "HealthEmployStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_MainGroups_MainGroupId",
                table: "Groups",
                column: "MainGroupId",
                principalTable: "MainGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Employ_EmployId",
                table: "Users",
                column: "EmployId",
                principalTable: "Employ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_GroupId",
                table: "Users",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
