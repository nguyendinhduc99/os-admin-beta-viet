using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class addKhuDoThi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KhuDoThi",
                table: "LoiThe_ShowRoom_BoSuuTap",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KhuDoThi",
                table: "DuAnNoiThat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KhuDoThi",
                table: "DuAnKienTruc",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KhuDoThi",
                table: "DangThiCong",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KhuDoThi",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuDoThi", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhuDoThi");

            migrationBuilder.DropColumn(
                name: "KhuDoThi",
                table: "LoiThe_ShowRoom_BoSuuTap");

            migrationBuilder.DropColumn(
                name: "KhuDoThi",
                table: "DuAnNoiThat");

            migrationBuilder.DropColumn(
                name: "KhuDoThi",
                table: "DuAnKienTruc");

            migrationBuilder.DropColumn(
                name: "KhuDoThi",
                table: "DangThiCong");
        }
    }
}
