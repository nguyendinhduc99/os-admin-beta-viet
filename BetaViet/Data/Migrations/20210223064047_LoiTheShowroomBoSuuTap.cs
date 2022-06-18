using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class LoiTheShowroomBoSuuTap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoiThe_ShowRoom_BoSuuTap",
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
                    ImageSections = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoiThe_ShowRoom_BoSuuTap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoiThe_ShowRoom_BoSuuTap_NhaThietKe_NhaThietKeId",
                        column: x => x.NhaThietKeId,
                        principalTable: "NhaThietKe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoiThe_ShowRoom_BoSuuTap_NhaThietKeId",
                table: "LoiThe_ShowRoom_BoSuuTap",
                column: "NhaThietKeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoiThe_ShowRoom_BoSuuTap");
        }
    }
}
