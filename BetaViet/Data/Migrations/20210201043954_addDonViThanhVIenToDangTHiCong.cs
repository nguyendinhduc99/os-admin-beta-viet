using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class addDonViThanhVIenToDangTHiCong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DonViThanhVienId",
                table: "DangThiCong",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DangThiCong_DonViThanhVienId",
                table: "DangThiCong",
                column: "DonViThanhVienId");

            migrationBuilder.AddForeignKey(
                name: "FK_DangThiCong_DonViThanhVien_DonViThanhVienId",
                table: "DangThiCong",
                column: "DonViThanhVienId",
                principalTable: "DonViThanhVien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DangThiCong_DonViThanhVien_DonViThanhVienId",
                table: "DangThiCong");

            migrationBuilder.DropIndex(
                name: "IX_DangThiCong_DonViThanhVienId",
                table: "DangThiCong");

            migrationBuilder.DropColumn(
                name: "DonViThanhVienId",
                table: "DangThiCong");
        }
    }
}
