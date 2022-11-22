using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class BedFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beds_PatientDto_PatientDtoId",
                table: "Beds");

            migrationBuilder.DropTable(
                name: "PatientDto");

            migrationBuilder.RenameColumn(
                name: "PatientDtoId",
                table: "Beds",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Beds_PatientDtoId",
                table: "Beds",
                newName: "IX_Beds_PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beds_Patients_PatientId",
                table: "Beds",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beds_Patients_PatientId",
                table: "Beds");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Beds",
                newName: "PatientDtoId");

            migrationBuilder.RenameIndex(
                name: "IX_Beds_PatientId",
                table: "Beds",
                newName: "IX_Beds_PatientDtoId");

            migrationBuilder.CreateTable(
                name: "PatientDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDto", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Beds_PatientDto_PatientDtoId",
                table: "Beds",
                column: "PatientDtoId",
                principalTable: "PatientDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
