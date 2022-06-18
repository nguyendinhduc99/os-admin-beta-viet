using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class addSEOTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SEOTags",
                table: "Video",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTags",
                table: "ToanCanh360NoiThat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTags",
                table: "ToanCanh360KienTruc",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTags",
                table: "NhaThietKe",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTags",
                table: "LoiThe_ShowRoom_BoSuuTap",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTags",
                table: "LanToaCongDong",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTags",
                table: "KhuyenmaiNoiThat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTags",
                table: "KhuyenmaiKienTruc",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTags",
                table: "DuAnNoiThat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTags",
                table: "DuAnKienTruc",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTags",
                table: "DonViThietKe",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTags",
                table: "DonViThanhVien",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTags",
                table: "DoiThiCong",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTags",
                table: "DanhMucVideo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTags",
                table: "DanhMucBaiViet",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTags",
                table: "DangThiCong",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEOTags",
                table: "BaiViet",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SEOTags",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "SEOTags",
                table: "ToanCanh360NoiThat");

            migrationBuilder.DropColumn(
                name: "SEOTags",
                table: "ToanCanh360KienTruc");

            migrationBuilder.DropColumn(
                name: "SEOTags",
                table: "NhaThietKe");

            migrationBuilder.DropColumn(
                name: "SEOTags",
                table: "LoiThe_ShowRoom_BoSuuTap");

            migrationBuilder.DropColumn(
                name: "SEOTags",
                table: "LanToaCongDong");

            migrationBuilder.DropColumn(
                name: "SEOTags",
                table: "KhuyenmaiNoiThat");

            migrationBuilder.DropColumn(
                name: "SEOTags",
                table: "KhuyenmaiKienTruc");

            migrationBuilder.DropColumn(
                name: "SEOTags",
                table: "DuAnNoiThat");

            migrationBuilder.DropColumn(
                name: "SEOTags",
                table: "DuAnKienTruc");

            migrationBuilder.DropColumn(
                name: "SEOTags",
                table: "DonViThietKe");

            migrationBuilder.DropColumn(
                name: "SEOTags",
                table: "DonViThanhVien");

            migrationBuilder.DropColumn(
                name: "SEOTags",
                table: "DoiThiCong");

            migrationBuilder.DropColumn(
                name: "SEOTags",
                table: "DanhMucVideo");

            migrationBuilder.DropColumn(
                name: "SEOTags",
                table: "DanhMucBaiViet");

            migrationBuilder.DropColumn(
                name: "SEOTags",
                table: "DangThiCong");

            migrationBuilder.DropColumn(
                name: "SEOTags",
                table: "BaiViet");
        }
    }
}
