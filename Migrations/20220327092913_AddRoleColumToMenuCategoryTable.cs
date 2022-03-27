using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityAPIPuzzle.Migrations
{
    public partial class AddRoleColumToMenuCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "MenuCategory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "706f240d-9ec2-4d92-86a6-8cd0b4c763d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5dd51b47-8e21-4ae3-aed6-3676e23ecfbb", "AQAAAAEAACcQAAAAEOTjydwpQIAq7CpOMrYYR88sfvmxO+8WVU3NMnzMqrgNTQ4EdSSilrywbRbHAh2cWw==", "db773b81-c1f6-4393-876d-1ce84f63533e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "MenuCategory");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "706f240d-9ec2-4d92-86a6-8cd0b4c763d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "841518ce-8dcb-4a75-b781-9f607bc585c9", "AQAAAAEAACcQAAAAEJQnjw7U1nQ5s0BLf7JOQoLXhp1pwHfdQww6rIM2AhlYvofaYHUHaINiQEtwZ1HxfA==", "74d605d9-3063-47ab-9faa-dded9e76cb38" });
        }
    }
}
