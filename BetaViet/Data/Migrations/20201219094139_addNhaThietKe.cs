using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class addNhaThietKe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NhaThietKeId",
                table: "DuAnNoiThat",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NhaThietKe",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    Properties = table.Column<string>(nullable: true),
                    Filters = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaThietKe", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuAnNoiThat_NhaThietKeId",
                table: "DuAnNoiThat",
                column: "NhaThietKeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DuAnNoiThat_NhaThietKe_NhaThietKeId",
                table: "DuAnNoiThat",
                column: "NhaThietKeId",
                principalTable: "NhaThietKe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DuAnNoiThat_NhaThietKe_NhaThietKeId",
                table: "DuAnNoiThat");

            migrationBuilder.DropTable(
                name: "NhaThietKe");

            migrationBuilder.DropIndex(
                name: "IX_DuAnNoiThat_NhaThietKeId",
                table: "DuAnNoiThat");

            migrationBuilder.DropColumn(
                name: "NhaThietKeId",
                table: "DuAnNoiThat");
        }
    }
}
