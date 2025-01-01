using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.UI.Migrations
{
    /// <inheritdoc />
    public partial class RoleColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PrintAccess",
                table: "RoleDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UploadAccess",
                table: "RoleDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrintAccess",
                table: "RoleDetails");

            migrationBuilder.DropColumn(
                name: "UploadAccess",
                table: "RoleDetails");
        }
    }
}
