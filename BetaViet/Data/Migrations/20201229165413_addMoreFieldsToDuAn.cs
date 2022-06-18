using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class addMoreFieldsToDuAn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdeaDescription",
                table: "DuAnNoiThat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectInfo",
                table: "DuAnNoiThat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdeaDescription",
                table: "DuAnKienTruc",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectInfo",
                table: "DuAnKienTruc",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdeaDescription",
                table: "DuAnNoiThat");

            migrationBuilder.DropColumn(
                name: "ProjectInfo",
                table: "DuAnNoiThat");

            migrationBuilder.DropColumn(
                name: "IdeaDescription",
                table: "DuAnKienTruc");

            migrationBuilder.DropColumn(
                name: "ProjectInfo",
                table: "DuAnKienTruc");
        }
    }
}
