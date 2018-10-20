using Microsoft.EntityFrameworkCore.Migrations;

namespace AirJobs.Data.Migrations
{
    public partial class FixOwnsOneConfigs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeoLocation_Altitude",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "GeoLocation_Course",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "GeoLocation_HorizontalAccuracy",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "GeoLocation_Speed",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "GeoLocation_VerticalAccuracy",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "Name_LastName",
                table: "User",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name_FirstName",
                table: "User",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "GeoLocation_Longitude",
                table: "Address",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "GeoLocation_Latitude",
                table: "Address",
                newName: "Latitude");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "User",
                newName: "Name_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "User",
                newName: "Name_FirstName");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Address",
                newName: "GeoLocation_Longitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Address",
                newName: "GeoLocation_Latitude");

            migrationBuilder.AddColumn<double>(
                name: "GeoLocation_Altitude",
                table: "Address",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GeoLocation_Course",
                table: "Address",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GeoLocation_HorizontalAccuracy",
                table: "Address",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GeoLocation_Speed",
                table: "Address",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GeoLocation_VerticalAccuracy",
                table: "Address",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}