using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaViet.Data.Migrations
{
    public partial class addPositionToNhaThietKe2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "DonViThietKe");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "NhaThietKe",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "DonViThietKe",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "NhaThietKe");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "DonViThietKe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "DonViThietKe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
