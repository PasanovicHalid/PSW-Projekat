using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class RoomFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Equipments_EquipmentId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_EquipmentId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Medicines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Bloods",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Beds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_RoomId",
                table: "Medicines",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bloods_RoomId",
                table: "Bloods",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Beds_RoomId",
                table: "Beds",
                column: "RoomId");

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
                name: "FK_Medicines_Rooms_RoomId",
                table: "Medicines",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beds_Rooms_RoomId",
                table: "Beds");

            migrationBuilder.DropForeignKey(
                name: "FK_Bloods_Rooms_RoomId",
                table: "Bloods");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Rooms_RoomId",
                table: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_RoomId",
                table: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_Bloods_RoomId",
                table: "Bloods");

            migrationBuilder.DropIndex(
                name: "IX_Beds_RoomId",
                table: "Beds");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Bloods");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Beds");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Rooms",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_EquipmentId",
                table: "Rooms",
                column: "EquipmentId");

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
                name: "FK_Rooms_Equipments_EquipmentId",
                table: "Rooms",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
