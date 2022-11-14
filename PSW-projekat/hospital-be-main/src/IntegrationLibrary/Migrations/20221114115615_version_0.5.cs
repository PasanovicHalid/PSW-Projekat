using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class version_05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BloodBankId",
                table: "BloodRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ReportSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDeliveryDate",
                value: new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodBankId",
                table: "BloodRequests");

            migrationBuilder.UpdateData(
                table: "ReportSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDeliveryDate",
                value: new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
