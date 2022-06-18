using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class addDoiThiCong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DoiThiCongId",
                table: "DangThiCong",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DoiThiCong",
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
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    Avatars = table.Column<string>(nullable: true),
                    Properties = table.Column<string>(nullable: true),
                    Filters = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoiThiCong", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DangThiCong_DoiThiCongId",
                table: "DangThiCong",
                column: "DoiThiCongId");

            migrationBuilder.AddForeignKey(
                name: "FK_DangThiCong_DoiThiCong_DoiThiCongId",
                table: "DangThiCong",
                column: "DoiThiCongId",
                principalTable: "DoiThiCong",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DangThiCong_DoiThiCong_DoiThiCongId",
                table: "DangThiCong");

            migrationBuilder.DropTable(
                name: "DoiThiCong");

            migrationBuilder.DropIndex(
                name: "IX_DangThiCong_DoiThiCongId",
                table: "DangThiCong");

            migrationBuilder.DropColumn(
                name: "DoiThiCongId",
                table: "DangThiCong");
        }
    }
}
