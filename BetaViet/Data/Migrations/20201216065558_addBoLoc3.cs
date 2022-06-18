using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class addBoLoc3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DropdownValues",
                table: "BoLoc");

            migrationBuilder.AddColumn<string>(
                name: "DropdownValuesJSON",
                table: "BoLoc",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DropdownValuesJSON",
                table: "BoLoc");

            migrationBuilder.AddColumn<string>(
                name: "DropdownValues",
                table: "BoLoc",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
