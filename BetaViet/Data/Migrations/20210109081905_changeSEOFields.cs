using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class changeSEOFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Page",
                table: "SEOText",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SEOText",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "SEOText",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "SEOText");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "SEOText");

            migrationBuilder.AlterColumn<int>(
                name: "Page",
                table: "SEOText",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
