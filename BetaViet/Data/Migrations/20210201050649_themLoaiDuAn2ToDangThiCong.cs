using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class themLoaiDuAn2ToDangThiCong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoaiDuAn2",
                table: "DangThiCong",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TienDoThiCong2",
                table: "DangThiCong",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoaiDuAn2",
                table: "DangThiCong");

            migrationBuilder.DropColumn(
                name: "TienDoThiCong2",
                table: "DangThiCong");
        }
    }
}
