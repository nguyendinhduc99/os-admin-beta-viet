using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class addDuAnNoiThat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DuAnNoiThat",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Avatars = table.Column<string>(nullable: true),
                    Properties = table.Column<string>(nullable: true),
                    Filters = table.Column<string>(nullable: true),
                    ImageSections = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuAnNoiThat", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuAnNoiThat");
        }
    }
}
