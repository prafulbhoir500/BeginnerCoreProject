using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.UI.Migrations
{
    /// <inheritdoc />
    public partial class columnchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedAccess",
                table: "AppModuleTemplates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ApprovedAccess",
                table: "AppModuleTemplates",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
