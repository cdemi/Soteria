using Microsoft.EntityFrameworkCore.Migrations;

namespace Soteria.Data.SqlServer.Migrations
{
    public partial class ReconfiguredIndices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LoginHistories_Username_DateTime",
                table: "LoginHistories");

            migrationBuilder.CreateIndex(
                name: "IX_LoginHistories_DateTime",
                table: "LoginHistories",
                column: "DateTime");

            migrationBuilder.CreateIndex(
                name: "IX_LoginHistories_Username",
                table: "LoginHistories",
                column: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LoginHistories_DateTime",
                table: "LoginHistories");

            migrationBuilder.DropIndex(
                name: "IX_LoginHistories_Username",
                table: "LoginHistories");

            migrationBuilder.CreateIndex(
                name: "IX_LoginHistories_Username_DateTime",
                table: "LoginHistories",
                columns: new[] { "Username", "DateTime" });
        }
    }
}
