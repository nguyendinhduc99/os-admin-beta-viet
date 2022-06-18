using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class addDuAnCommon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "DuAnNoiThat");

            migrationBuilder.CreateTable(
                name: "DuAnKienTruc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    TrangThaiDuAn = table.Column<int>(nullable: false),
                    TienDoThiCong = table.Column<string>(nullable: true),
                    NhaThietKeId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    Avatars = table.Column<string>(nullable: true),
                    Properties = table.Column<string>(nullable: true),
                    Filters = table.Column<string>(nullable: true),
                    ImageSections = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuAnKienTruc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuAnKienTruc_NhaThietKe_NhaThietKeId",
                        column: x => x.NhaThietKeId,
                        principalTable: "NhaThietKe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuAnKienTruc_NhaThietKeId",
                table: "DuAnKienTruc",
                column: "NhaThietKeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuAnKienTruc");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "DuAnNoiThat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
