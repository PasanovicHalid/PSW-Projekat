using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class AddressVO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Persons",
                newName: "Email_Adress");

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Number",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PostCode",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Township",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Shift_EndTime_Hour",
                table: "DoctorSchedule",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Shift_EndTime_Minute",
                table: "DoctorSchedule",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Shift_StartTime_Hour",
                table: "DoctorSchedule",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Shift_StartTime_Minute",
                table: "DoctorSchedule",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CancelationDate",
                table: "Appointments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Address_Number",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Address_PostCode",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Address_Township",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Shift_EndTime_Hour",
                table: "DoctorSchedule");

            migrationBuilder.DropColumn(
                name: "Shift_EndTime_Minute",
                table: "DoctorSchedule");

            migrationBuilder.DropColumn(
                name: "Shift_StartTime_Hour",
                table: "DoctorSchedule");

            migrationBuilder.DropColumn(
                name: "Shift_StartTime_Minute",
                table: "DoctorSchedule");

            migrationBuilder.RenameColumn(
                name: "Email_Adress",
                table: "Persons",
                newName: "Email");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CancelationDate",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
