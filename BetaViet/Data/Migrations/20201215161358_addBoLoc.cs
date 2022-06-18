using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class addBoLoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoLoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Values = table.Column<string>(nullable: true),
                    Dropdown = table.Column<bool>(nullable: false),
                    DropdownValues = table.Column<string>(nullable: true),
                    Page = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoLoc", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoLoc");
        }
    }
}
