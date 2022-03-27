using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityAPIPuzzle.Migrations
{
    public partial class AddMenuCategorySeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "706f240d-9ec2-4d92-86a6-8cd0b4c763d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "841518ce-8dcb-4a75-b781-9f607bc585c9", "AQAAAAEAACcQAAAAEJQnjw7U1nQ5s0BLf7JOQoLXhp1pwHfdQww6rIM2AhlYvofaYHUHaINiQEtwZ1HxfA==", "74d605d9-3063-47ab-9faa-dded9e76cb38" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "706f240d-9ec2-4d92-86a6-8cd0b4c763d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b194a75-1c94-4b55-bbe4-ad8bccf6654b", "AQAAAAEAACcQAAAAELBy3ESk1zf+5aIy0yw7Vk+7KY0w3UXMy30cOhhUzp5y15c0GL6t3XEyMrFySNFWgw==", "b537bb59-cd4e-45bb-a6c6-20eb30b24d2a" });
        }
    }
}
