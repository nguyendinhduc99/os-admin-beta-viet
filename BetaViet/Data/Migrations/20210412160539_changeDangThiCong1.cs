using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class changeDangThiCong1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoaiDuAn",
                table: "DangThiCong");

            migrationBuilder.DropColumn(
                name: "LoaiDuAn2",
                table: "DangThiCong");

            migrationBuilder.DropColumn(
                name: "TienDoThiCong",
                table: "DangThiCong");

            migrationBuilder.DropColumn(
                name: "TienDoThiCong2",
                table: "DangThiCong");

            migrationBuilder.AddColumn<string>(
                name: "DoiThiCong",
                table: "DangThiCong",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoiThiCong",
                table: "DangThiCong");

            migrationBuilder.AddColumn<int>(
                name: "LoaiDuAn",
                table: "DangThiCong",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LoaiDuAn2",
                table: "DangThiCong",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TienDoThiCong",
                table: "DangThiCong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TienDoThiCong2",
                table: "DangThiCong",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
