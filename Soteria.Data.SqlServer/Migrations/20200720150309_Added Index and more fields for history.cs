using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Soteria.Data.SqlServer.Migrations
{
    public partial class AddedIndexandmorefieldsforhistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "LoginHistories",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "LoginHistories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "LoginHistories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IP",
                table: "LoginHistories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "LoginHistories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAgent",
                table: "LoginHistories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoginHistories_Username_DateTime",
                table: "LoginHistories",
                columns: new[] { "Username", "DateTime" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LoginHistories_Username_DateTime",
                table: "LoginHistories");

            migrationBuilder.DropColumn(
                name: "City",
                table: "LoginHistories");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "LoginHistories");

            migrationBuilder.DropColumn(
                name: "IP",
                table: "LoginHistories");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "LoginHistories");

            migrationBuilder.DropColumn(
                name: "UserAgent",
                table: "LoginHistories");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "LoginHistories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
