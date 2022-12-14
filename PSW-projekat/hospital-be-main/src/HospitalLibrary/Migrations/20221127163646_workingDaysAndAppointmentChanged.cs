using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class workingDaysAndAppointmentChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beds_PatientDto_PatientDtoId",
                table: "Beds");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Persons_PersonId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientAllergies_Allergies_AllergyId",
                table: "PatientAllergies");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientAllergies_Patients_PatientId",
                table: "PatientAllergies");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Equipments_EquipmentId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingDays_Persons_UserId",
                table: "WorkingDays");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "PatientDto");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_EquipmentId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_PatientAllergies_AllergyId",
                table: "PatientAllergies");

            migrationBuilder.DropIndex(
                name: "IX_PatientAllergies_PatientId",
                table: "PatientAllergies");

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "WorkingDays");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "WorkingDays",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkingDays_UserId",
                table: "WorkingDays",
                newName: "IX_WorkingDays_DoctorId");

            migrationBuilder.RenameColumn(
                name: "PatientDtoId",
                table: "Beds",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Beds_PatientDtoId",
                table: "Beds",
                newName: "IX_Beds_RoomId");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "PatientAllergies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AllergyId",
                table: "PatientAllergies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Medicines",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Doctors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Bloods",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Beds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CancelationDate",
                table: "Appointments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_RoomId",
                table: "Medicines",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bloods_RoomId",
                table: "Bloods",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Beds_PatientId",
                table: "Beds",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beds_Patients_PatientId",
                table: "Beds",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Beds_Rooms_RoomId",
                table: "Beds",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bloods_Rooms_RoomId",
                table: "Bloods",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Persons_PersonId",
                table: "Doctors",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Rooms_RoomId",
                table: "Medicines",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingDays_Doctors_DoctorId",
                table: "WorkingDays",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beds_Patients_PatientId",
                table: "Beds");

            migrationBuilder.DropForeignKey(
                name: "FK_Beds_Rooms_RoomId",
                table: "Beds");

            migrationBuilder.DropForeignKey(
                name: "FK_Bloods_Rooms_RoomId",
                table: "Bloods");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Persons_PersonId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Rooms_RoomId",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingDays_Doctors_DoctorId",
                table: "WorkingDays");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_RoomId",
                table: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_Bloods_RoomId",
                table: "Bloods");

            migrationBuilder.DropIndex(
                name: "IX_Beds_PatientId",
                table: "Beds");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Bloods");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Beds");

            migrationBuilder.DropColumn(
                name: "CancelationDate",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "WorkingDays",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkingDays_DoctorId",
                table: "WorkingDays",
                newName: "IX_WorkingDays_UserId");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Beds",
                newName: "PatientDtoId");

            migrationBuilder.RenameIndex(
                name: "IX_Beds_RoomId",
                table: "Beds",
                newName: "IX_Beds_PatientDtoId");

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "WorkingDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "PatientAllergies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AllergyId",
                table: "PatientAllergies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedId = table.Column<int>(type: "int", nullable: true),
                    BloodId = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_Beds_BedId",
                        column: x => x.BedId,
                        principalTable: "Beds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipments_Bloods_BloodId",
                        column: x => x.BloodId,
                        principalTable: "Bloods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipments_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.InsertData(
                table: "Allergies",
                columns: new[] { "Id", "Deleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Polen" },
                    { 2, false, "Prasina" },
                    { 3, false, "Pas" },
                    { 4, false, "Macka" },
                    { 5, false, "Pcela" },
                    { 6, false, "Ambrozija" },
                    { 7, false, "Kikiriki" },
                    { 8, false, "Gluten" },
                    { 9, false, "Laktoza" },
                    { 10, false, "Alergija10" },
                    { 11, false, "Alergija11" },
                    { 12, false, "Alergija12" },
                    { 13, false, "Alergija13" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_EquipmentId",
                table: "Rooms",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAllergies_AllergyId",
                table: "PatientAllergies",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAllergies_PatientId",
                table: "PatientAllergies",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_BedId",
                table: "Equipments",
                column: "BedId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_BloodId",
                table: "Equipments",
                column: "BloodId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_MedicineId",
                table: "Equipments",
                column: "MedicineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beds_PatientDto_PatientDtoId",
                table: "Beds",
                column: "PatientDtoId",
                principalTable: "PatientDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Persons_PersonId",
                table: "Doctors",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAllergies_Allergies_AllergyId",
                table: "PatientAllergies",
                column: "AllergyId",
                principalTable: "Allergies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAllergies_Patients_PatientId",
                table: "PatientAllergies",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Equipments_EquipmentId",
                table: "Rooms",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingDays_Persons_UserId",
                table: "WorkingDays",
                column: "UserId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
