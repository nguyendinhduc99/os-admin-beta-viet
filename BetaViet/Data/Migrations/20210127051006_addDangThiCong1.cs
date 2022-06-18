using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class addDangThiCong1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DangThiCong",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    SEOTitle = table.Column<string>(nullable: true),
                    SEODescription = table.Column<string>(nullable: true),
                    SEOText = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    NhaThietKeId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    ProjectInfo = table.Column<string>(nullable: true),
                    IdeaDescription = table.Column<string>(nullable: true),
                    Avatars = table.Column<string>(nullable: true),
                    Properties = table.Column<string>(nullable: true),
                    Filters = table.Column<string>(nullable: true),
                    ImageSections = table.Column<string>(nullable: true),
                    LoaiDuAn = table.Column<int>(nullable: false),
                    TienDoThiCong = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangThiCong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DangThiCong_NhaThietKe_NhaThietKeId",
                        column: x => x.NhaThietKeId,
                        principalTable: "NhaThietKe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DangThiCong_NhaThietKeId",
                table: "DangThiCong",
                column: "NhaThietKeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DangThiCong");
        }
    }
}
