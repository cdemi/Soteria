using Microsoft.EntityFrameworkCore.Migrations;

namespace Soteria.Data.SqlServer.Migrations
{
    public partial class AddedevenmorefieldstotheLoginHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AutonomousSystemNumber",
                table: "LoginHistories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AutonomousSystemOrganization",
                table: "LoginHistories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConnectionType",
                table: "LoginHistories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Domain",
                table: "LoginHistories",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAnonymous",
                table: "LoginHistories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAnonymousProxy",
                table: "LoginHistories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAnonymousVpn",
                table: "LoginHistories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHostingProvider",
                table: "LoginHistories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLegitimateProxy",
                table: "LoginHistories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublicProxy",
                table: "LoginHistories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSatelliteProvider",
                table: "LoginHistories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTorExitNode",
                table: "LoginHistories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Isp",
                table: "LoginHistories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Organization",
                table: "LoginHistories",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "StaticIPScore",
                table: "LoginHistories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "LoginHistories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutonomousSystemNumber",
                table: "LoginHistories");

            migrationBuilder.DropColumn(
                name: "AutonomousSystemOrganization",
                table: "LoginHistories");

            migrationBuilder.DropColumn(
                name: "ConnectionType",
                table: "LoginHistories");

            migrationBuilder.DropColumn(
                name: "Domain",
                table: "LoginHistories");

            migrationBuilder.DropColumn(
                name: "IsAnonymous",
                table: "LoginHistories");

            migrationBuilder.DropColumn(
                name: "IsAnonymousProxy",
                table: "LoginHistories");

            migrationBuilder.DropColumn(
                name: "IsAnonymousVpn",
                table: "LoginHistories");

            migrationBuilder.DropColumn(
                name: "IsHostingProvider",
                table: "LoginHistories");

            migrationBuilder.DropColumn(
                name: "IsLegitimateProxy",
                table: "LoginHistories");

            migrationBuilder.DropColumn(
                name: "IsPublicProxy",
                table: "LoginHistories");

            migrationBuilder.DropColumn(
                name: "IsSatelliteProvider",
                table: "LoginHistories");

            migrationBuilder.DropColumn(
                name: "IsTorExitNode",
                table: "LoginHistories");

            migrationBuilder.DropColumn(
                name: "Isp",
                table: "LoginHistories");

            migrationBuilder.DropColumn(
                name: "Organization",
                table: "LoginHistories");

            migrationBuilder.DropColumn(
                name: "StaticIPScore",
                table: "LoginHistories");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "LoginHistories");
        }
    }
}
