using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class changeDOnVi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "DonViThietKeId",
                table: "NhaThietKe",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DonViThietKeId",
                table: "DangThiCong",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhaThietKe_DonViThietKeId",
                table: "NhaThietKe",
                column: "DonViThietKeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_NhaThietKe_DonViThietKe_DonViThietKeId",
                table: "NhaThietKe",
                column: "DonViThietKeId",
                principalTable: "DonViThietKe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DangThiCong_DonViThanhVien_DonViThietKeId",
                table: "DangThiCong");

            migrationBuilder.DropForeignKey(
                name: "FK_NhaThietKe_DonViThietKe_DonViThietKeId",
                table: "NhaThietKe");

            migrationBuilder.DropIndex(
                name: "IX_NhaThietKe_DonViThietKeId",
                table: "NhaThietKe");

            migrationBuilder.DropIndex(
                name: "IX_DangThiCong_DonViThietKeId",
                table: "DangThiCong");

            migrationBuilder.DropColumn(
                name: "DonViThietKeId",
                table: "NhaThietKe");

            migrationBuilder.DropColumn(
                name: "DonViThietKeId",
                table: "DangThiCong");

            migrationBuilder.AddColumn<Guid>(
                name: "DonViThanhVienId",
                table: "DangThiCong",
                type: "uniqueidentifier",
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
    }
}
