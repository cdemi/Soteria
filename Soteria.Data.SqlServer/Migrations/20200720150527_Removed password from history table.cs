using Microsoft.EntityFrameworkCore.Migrations;

namespace Soteria.Data.SqlServer.Migrations
{
    public partial class Removedpasswordfromhistorytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "LoginHistories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "LoginHistories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
