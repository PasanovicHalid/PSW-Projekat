using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations.AuthenticationDb
{
    public partial class BlockedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58f7fb5f-09dc-4bee-813f-4e47940650c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93000374-46d9-44ef-ac96-6db416a28770");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d20bd231-b1fe-477b-be40-e4e38be41762");

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "93000374-46d9-44ef-ac96-6db416a28770", "9a23c8cc-acc0-4b5a-a247-3f5298277b76", "Doctor", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d20bd231-b1fe-477b-be40-e4e38be41762", "bb721e26-c59c-4ab5-be3e-63940807d492", "Patient", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "58f7fb5f-09dc-4bee-813f-4e47940650c4", "76feb459-393f-45d5-be10-46df582dd946", "Manager", null });
        }
    }
}
