using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class version_05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BloodBanks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReportSettings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "BloodRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "BloodRequests",
                columns: new[] { "Id", "BloodQuantity", "BloodType", "Comment", "DoctorId", "Reason", "RequestState", "RequiredForDate" },
                values: new object[] { 1, 5, 6, null, 4, "asdasdadsadsdas", 0, new DateTime(2022, 11, 19, 16, 18, 2, 836, DateTimeKind.Local).AddTicks(8715) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BloodRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "BloodRequests");

            migrationBuilder.InsertData(
                table: "BloodBanks",
                columns: new[] { "Id", "AccountStatus", "ApiKey", "Email", "Name", "Password", "PasswordResetKey", "ServerAddress" },
                values: new object[] { 1, 1, "sadfasdads", "asdasd@gmail.com", "asdsadsda", "asdsadsdadas", null, "https://www.messenger.com/t/100001603572170" });

            migrationBuilder.InsertData(
                table: "ReportSettings",
                columns: new[] { "Id", "CalculationDays", "CalculationMonths", "CalculationYears", "DeliveryDays", "DeliveryMonths", "DeliveryYears", "StartDeliveryDate" },
                values: new object[] { 1, 0, 1, 0, 0, 1, 0, new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
