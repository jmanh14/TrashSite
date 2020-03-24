using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashServiceWebsite.Data.Migrations
{
    public partial class AddedDayToPickUpvariable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c913c4b-db37-46ab-9edd-935d69cc684c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a56a10a1-65de-428a-8e58-ec9012516509");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b38f7efb-0ad3-4089-8578-ffb70b206906");

            migrationBuilder.AddColumn<int>(
                name: "DayToPickUp",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1766ffc6-58c8-456d-9bf6-3644350a752a", "9e1155ea-08f3-443e-b176-f8f13a0d364b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "422bd963-039e-4fcd-9a01-6b935c9ba124", "8d749367-9e45-4fef-adb0-f990709616ad", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1737113e-796a-4e6f-ab63-3b1c00cb8dca", "02165e49-703f-473e-8c8d-e739067fa68c", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1737113e-796a-4e6f-ab63-3b1c00cb8dca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1766ffc6-58c8-456d-9bf6-3644350a752a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422bd963-039e-4fcd-9a01-6b935c9ba124");

            migrationBuilder.DropColumn(
                name: "DayToPickUp",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a56a10a1-65de-428a-8e58-ec9012516509", "7d0af16f-68b4-4a5f-86a8-63995f251ab7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6c913c4b-db37-46ab-9edd-935d69cc684c", "26cc90a8-5099-4f76-989f-20ada1ff2fa5", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b38f7efb-0ad3-4089-8578-ffb70b206906", "22a8f53d-4885-40ee-9a53-a7fb7d7c39ce", "Employee", "EMPLOYEE" });
        }
    }
}
