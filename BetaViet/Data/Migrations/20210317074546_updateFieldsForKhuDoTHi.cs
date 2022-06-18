using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class updateFieldsForKhuDoTHi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "KhuDoThi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEODescription",
                table: "KhuDoThi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTags",
                table: "KhuDoThi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOText",
                table: "KhuDoThi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTitle",
                table: "KhuDoThi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "KhuDoThi",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "KhuDoThi");

            migrationBuilder.DropColumn(
                name: "SEODescription",
                table: "KhuDoThi");

            migrationBuilder.DropColumn(
                name: "SEOTags",
                table: "KhuDoThi");

            migrationBuilder.DropColumn(
                name: "SEOText",
                table: "KhuDoThi");

            migrationBuilder.DropColumn(
                name: "SEOTitle",
                table: "KhuDoThi");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "KhuDoThi");
        }
    }
}
