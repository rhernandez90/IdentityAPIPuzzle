using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityAPIPuzzle.Migrations
{
    public partial class AddRolesSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "fab4fac1-c546-41de-aebc-a14da6895711", "1", "Admin", "Admin" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "2", "User", "User" },
                    { "adfa8f88-1b57-4067-9052-5812141d04e4", "3", "Public", "Public" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "706f240d-9ec2-4d92-86a6-8cd0b4c763d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a0b50da-4ce8-46ee-8cea-7a873577361c", "AQAAAAEAACcQAAAAELtLYuwToDfrIWJUfmaj6gHRrl7u9J61ClzCGmYCtePNocp2g5jSIBW9eEnqSX7udA==", "f5cb8268-7cb9-473c-b91c-ca8cbec3ce7b" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "706f240d-9ec2-4d92-86a6-8cd0b4c763d3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adfa8f88-1b57-4067-9052-5812141d04e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7b013f0-5201-4317-abd8-c211f91b7330");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "706f240d-9ec2-4d92-86a6-8cd0b4c763d3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da6895711");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "706f240d-9ec2-4d92-86a6-8cd0b4c763d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b1242b4-f053-4fb2-b812-15afc205c100", "AQAAAAEAACcQAAAAEB1z2Vfu9n4hH2ObuhpWjuFrMJB/aAwrzSCjy8XJIGmZSIr5WOb+Ru9Xls6Y4wvQOg==", "ba52dc37-c423-4c9c-a33d-8bb085f713e9" });
        }
    }
}
