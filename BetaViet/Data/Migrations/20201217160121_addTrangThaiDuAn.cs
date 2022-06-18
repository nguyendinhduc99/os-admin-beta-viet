using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class addTrangThaiDuAn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "DuAnNoiThat",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Avatars",
                table: "DuAnNoiThat",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DuAnNoiThat",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TienDoThiCong",
                table: "DuAnNoiThat",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrangThaiDuAn",
                table: "DuAnNoiThat",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BoLoc",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "TienDoThiCong",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Page = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TienDoThiCong", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TienDoThiCong");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DuAnNoiThat");

            migrationBuilder.DropColumn(
                name: "TienDoThiCong",
                table: "DuAnNoiThat");

            migrationBuilder.DropColumn(
                name: "TrangThaiDuAn",
                table: "DuAnNoiThat");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BoLoc");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "DuAnNoiThat",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Avatars",
                table: "DuAnNoiThat",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
