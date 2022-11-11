using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class version_03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryYears = table.Column<int>(type: "int", nullable: false),
                    DeliveryMonths = table.Column<int>(type: "int", nullable: false),
                    DeliveryDays = table.Column<int>(type: "int", nullable: false),
                    CalculationYears = table.Column<int>(type: "int", nullable: false),
                    CalculationMonths = table.Column<int>(type: "int", nullable: false),
                    CalculationDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportSettings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ReportSettings",
                columns: new[] { "Id", "CalculationDays", "CalculationMonths", "CalculationYears", "DeliveryDays", "DeliveryMonths", "DeliveryYears", "StartDeliveryDate" },
                values: new object[] { 1, 0, 1, 0, 0, 1, 0, new DateTime(2022, 11, 7, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportSettings");
        }
    }
}
