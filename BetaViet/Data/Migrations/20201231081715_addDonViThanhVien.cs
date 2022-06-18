using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class addDonViThanhVien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DonViThanhVienId",
                table: "NhaThietKe",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DonViThanhVien",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    Properties = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonViThanhVien", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NhaThietKe_DonViThanhVienId",
                table: "NhaThietKe",
                column: "DonViThanhVienId");

            migrationBuilder.AddForeignKey(
                name: "FK_NhaThietKe_DonViThanhVien_DonViThanhVienId",
                table: "NhaThietKe",
                column: "DonViThanhVienId",
                principalTable: "DonViThanhVien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhaThietKe_DonViThanhVien_DonViThanhVienId",
                table: "NhaThietKe");

            migrationBuilder.DropTable(
                name: "DonViThanhVien");

            migrationBuilder.DropIndex(
                name: "IX_NhaThietKe_DonViThanhVienId",
                table: "NhaThietKe");

            migrationBuilder.DropColumn(
                name: "DonViThanhVienId",
                table: "NhaThietKe");
        }
    }
}
