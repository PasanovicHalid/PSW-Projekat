using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class DoctorCouncil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_DoctorsCouncils_DoctorsCouncilId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_DoctorsCouncilId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DoctorsCouncilId",
                table: "Doctors");

            migrationBuilder.CreateTable(
                name: "DoctorDoctorsCouncil",
                columns: table => new
                {
                    CouncilsId = table.Column<int>(type: "int", nullable: false),
                    DoctorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorDoctorsCouncil", x => new { x.CouncilsId, x.DoctorsId });
                    table.ForeignKey(
                        name: "FK_DoctorDoctorsCouncil_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorDoctorsCouncil_DoctorsCouncils_CouncilsId",
                        column: x => x.CouncilsId,
                        principalTable: "DoctorsCouncils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorDoctorsCouncil_DoctorsId",
                table: "DoctorDoctorsCouncil",
                column: "DoctorsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorDoctorsCouncil");

            migrationBuilder.AddColumn<int>(
                name: "DoctorsCouncilId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorsCouncilId",
                table: "Doctors",
                column: "DoctorsCouncilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_DoctorsCouncils_DoctorsCouncilId",
                table: "Doctors",
                column: "DoctorsCouncilId",
                principalTable: "DoctorsCouncils",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
