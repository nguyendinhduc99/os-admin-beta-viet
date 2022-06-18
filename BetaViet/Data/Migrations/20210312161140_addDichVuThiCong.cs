using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class addDichVuThiCong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DichVuThiCong",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    SEOTitle = table.Column<string>(nullable: true),
                    SEODescription = table.Column<string>(nullable: true),
                    SEOText = table.Column<string>(nullable: true),
                    SEOTags = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    Page = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Avatar = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    NhaThietKeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVuThiCong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DichVuThiCong_NhaThietKe_NhaThietKeId",
                        column: x => x.NhaThietKeId,
                        principalTable: "NhaThietKe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DichVuThiCong_NhaThietKeId",
                table: "DichVuThiCong",
                column: "NhaThietKeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DichVuThiCong");
        }
    }
}
