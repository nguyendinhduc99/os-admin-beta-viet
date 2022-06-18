using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class addDangThiCong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TienDoThiCong",
                table: "DuAnNoiThat");

            migrationBuilder.DropColumn(
                name: "TrangThaiDuAn",
                table: "DuAnNoiThat");

            migrationBuilder.DropColumn(
                name: "TienDoThiCong",
                table: "DuAnKienTruc");

            migrationBuilder.DropColumn(
                name: "TrangThaiDuAn",
                table: "DuAnKienTruc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TienDoThiCong",
                table: "DuAnNoiThat",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrangThaiDuAn",
                table: "DuAnNoiThat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TienDoThiCong",
                table: "DuAnKienTruc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrangThaiDuAn",
                table: "DuAnKienTruc",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
