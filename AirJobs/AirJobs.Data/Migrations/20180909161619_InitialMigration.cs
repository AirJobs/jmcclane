using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirJobs.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Country",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>("varchar(150)", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Country", x => x.Id); });

            migrationBuilder.CreateTable(
                "State",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>("varchar(150)", nullable: false),
                    UF = table.Column<string>("varchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        "FK_State_Country_CountryId",
                        x => x.CountryId,
                        "Country",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "City",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>("varchar(100)", nullable: false),
                    StateId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        "FK_City_State_StateId",
                        x => x.StateId,
                        "State",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Address",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CityId = table.Column<Guid>(nullable: false),
                    Neighborhood = table.Column<string>("varchar(250)", nullable: false),
                    Number = table.Column<string>("varchar(15)", nullable: false),
                    Street = table.Column<string>("varchar(500)", nullable: false),
                    GeoLocation_Altitude = table.Column<double>(nullable: false),
                    GeoLocation_Course = table.Column<double>(nullable: false),
                    GeoLocation_HorizontalAccuracy = table.Column<double>(nullable: false),
                    GeoLocation_Latitude = table.Column<double>(nullable: false),
                    GeoLocation_Longitude = table.Column<double>(nullable: false),
                    GeoLocation_Speed = table.Column<double>(nullable: false),
                    GeoLocation_VerticalAccuracy = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        "FK_Address_City_CityId",
                        x => x.CityId,
                        "City",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Job",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    Description = table.Column<string>("varchar(max)", nullable: true),
                    ImageUrl = table.Column<string>("varchar(max)", nullable: true),
                    Price = table.Column<decimal>("money", nullable: false),
                    Title = table.Column<string>("varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                    table.ForeignKey(
                        "FK_Job_Address_AddressId",
                        x => x.AddressId,
                        "Address",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "User",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: false),
                    Name_FirstName = table.Column<string>("varchar(30)", nullable: false),
                    Name_LastName = table.Column<string>("varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        "FK_User_Address_AddressId",
                        x => x.AddressId,
                        "Address",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Address_CityId",
                "Address",
                "CityId");

            migrationBuilder.CreateIndex(
                "IX_City_StateId",
                "City",
                "StateId");

            migrationBuilder.CreateIndex(
                "IX_Job_AddressId",
                "Job",
                "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_State_CountryId",
                "State",
                "CountryId");

            migrationBuilder.CreateIndex(
                "IX_User_AddressId",
                "User",
                "AddressId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Job");

            migrationBuilder.DropTable(
                "User");

            migrationBuilder.DropTable(
                "Address");

            migrationBuilder.DropTable(
                "City");

            migrationBuilder.DropTable(
                "State");

            migrationBuilder.DropTable(
                "Country");
        }
    }
}