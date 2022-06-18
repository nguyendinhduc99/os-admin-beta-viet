using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class addSeoFieldsToEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SEODescription",
                table: "NhaThietKe",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOText",
                table: "NhaThietKe",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTitle",
                table: "NhaThietKe",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEODescription",
                table: "DuAnNoiThat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOText",
                table: "DuAnNoiThat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTitle",
                table: "DuAnNoiThat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEODescription",
                table: "DuAnKienTruc",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOText",
                table: "DuAnKienTruc",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTitle",
                table: "DuAnKienTruc",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEODescription",
                table: "DonViThanhVien",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOText",
                table: "DonViThanhVien",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTitle",
                table: "DonViThanhVien",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SEODescription",
                table: "NhaThietKe");

            migrationBuilder.DropColumn(
                name: "SEOText",
                table: "NhaThietKe");

            migrationBuilder.DropColumn(
                name: "SEOTitle",
                table: "NhaThietKe");

            migrationBuilder.DropColumn(
                name: "SEODescription",
                table: "DuAnNoiThat");

            migrationBuilder.DropColumn(
                name: "SEOText",
                table: "DuAnNoiThat");

            migrationBuilder.DropColumn(
                name: "SEOTitle",
                table: "DuAnNoiThat");

            migrationBuilder.DropColumn(
                name: "SEODescription",
                table: "DuAnKienTruc");

            migrationBuilder.DropColumn(
                name: "SEOText",
                table: "DuAnKienTruc");

            migrationBuilder.DropColumn(
                name: "SEOTitle",
                table: "DuAnKienTruc");

            migrationBuilder.DropColumn(
                name: "SEODescription",
                table: "DonViThanhVien");

            migrationBuilder.DropColumn(
                name: "SEOText",
                table: "DonViThanhVien");

            migrationBuilder.DropColumn(
                name: "SEOTitle",
                table: "DonViThanhVien");
        }
    }
}
