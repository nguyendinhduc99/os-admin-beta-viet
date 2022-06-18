using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class addSlugToBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "NhaThietKe",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "DuAnNoiThat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "DuAnKienTruc",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "DonViThanhVien",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "NhaThietKe");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "DuAnNoiThat");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "DuAnKienTruc");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "DonViThanhVien");
        }
    }
}
