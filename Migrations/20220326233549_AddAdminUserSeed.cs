using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityAPIPuzzle.Migrations
{
    public partial class AddAdminUserSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "706f240d-9ec2-4d92-86a6-8cd0b4c763d3", 3, "0b1242b4-f053-4fb2-b812-15afc205c100", "rhernandezmunugia@gmail.com", true, false, null, "rhernandezmunguia@gmail.com", "administrator", "AQAAAAEAACcQAAAAEB1z2Vfu9n4hH2ObuhpWjuFrMJB/aAwrzSCjy8XJIGmZSIr5WOb+Ru9Xls6Y4wvQOg==", null, false, "ba52dc37-c423-4c9c-a33d-8bb085f713e9", false, "administrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "706f240d-9ec2-4d92-86a6-8cd0b4c763d3");
        }
    }
}
