using Microsoft.EntityFrameworkCore.Migrations;

namespace Soteria.Data.SqlServer.Migrations
{
    public partial class AddedmorefieldstotheLoginHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Continent",
                table: "LoginHistories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "LoginHistories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Continent",
                table: "LoginHistories");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "LoginHistories");
        }
    }
}
