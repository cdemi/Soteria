using Microsoft.EntityFrameworkCore.Migrations;

namespace Soteria.Data.SqlServer.Migrations
{
    public partial class AddedCoOrdinatestotheLoginHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "LoginHistories",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "LoginHistories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "LoginHistories");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "LoginHistories");
        }
    }
}
