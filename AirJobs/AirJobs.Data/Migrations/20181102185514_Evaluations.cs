using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirJobs.Data.Migrations
{
    public partial class Evaluations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evaluation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Stars = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", nullable: false),
                    JobId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    SchedulingId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluation_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluation_Scheduling_SchedulingId",
                        column: x => x.SchedulingId,
                        principalTable: "Scheduling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_JobId",
                table: "Evaluation",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_SchedulingId",
                table: "Evaluation",
                column: "SchedulingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_UserId",
                table: "Evaluation",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluation");
        }
    }
}
