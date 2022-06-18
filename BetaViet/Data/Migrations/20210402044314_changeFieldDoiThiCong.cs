using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class changeFieldDoiThiCong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatars",
                table: "DoiThiCong");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "DoiThiCong",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "DoiThiCong",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "DoiThiCong");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "DoiThiCong");

            migrationBuilder.AddColumn<string>(
                name: "Avatars",
                table: "DoiThiCong",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
