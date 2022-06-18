using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class addSoLuotTruyCap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SoLuotTruyCap",
                table: "LoiThe_ShowRoom_BoSuuTap",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoLuotTruyCap",
                table: "DuAnNoiThat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoLuotTruyCap",
                table: "DuAnKienTruc",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoLuotTruyCap",
                table: "DangThiCong",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoLuotTruyCap",
                table: "LoiThe_ShowRoom_BoSuuTap");

            migrationBuilder.DropColumn(
                name: "SoLuotTruyCap",
                table: "DuAnNoiThat");

            migrationBuilder.DropColumn(
                name: "SoLuotTruyCap",
                table: "DuAnKienTruc");

            migrationBuilder.DropColumn(
                name: "SoLuotTruyCap",
                table: "DangThiCong");
        }
    }
}
