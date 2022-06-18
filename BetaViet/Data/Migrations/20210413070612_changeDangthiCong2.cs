using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class changeDangthiCong2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DangThiCong_DonViThanhVien_DonViThietKeId",
                table: "DangThiCong");

            migrationBuilder.DropIndex(
                name: "IX_DangThiCong_DonViThietKeId",
                table: "DangThiCong");

            migrationBuilder.DropColumn(
                name: "DonViThietKeId",
                table: "DangThiCong");

            migrationBuilder.AddColumn<string>(
                name: "ThietKe",
                table: "DangThiCong",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThietKe",
                table: "DangThiCong");

            migrationBuilder.AddColumn<Guid>(
                name: "DonViThietKeId",
                table: "DangThiCong",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DangThiCong_DonViThietKeId",
                table: "DangThiCong",
                column: "DonViThietKeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DangThiCong_DonViThanhVien_DonViThietKeId",
                table: "DangThiCong",
                column: "DonViThietKeId",
                principalTable: "DonViThanhVien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
