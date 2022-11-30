using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class DoctorCouncil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorsCouncilId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DoctorsCouncils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<float>(type: "real", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorsCouncils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorsCouncils_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorsCouncilId",
                table: "Doctors",
                column: "DoctorsCouncilId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorsCouncils_DoctorId",
                table: "DoctorsCouncils",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_DoctorsCouncils_DoctorsCouncilId",
                table: "Doctors",
                column: "DoctorsCouncilId",
                principalTable: "DoctorsCouncils",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_DoctorsCouncils_DoctorsCouncilId",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "DoctorsCouncils");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_DoctorsCouncilId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DoctorsCouncilId",
                table: "Doctors");
        }
    }
}
