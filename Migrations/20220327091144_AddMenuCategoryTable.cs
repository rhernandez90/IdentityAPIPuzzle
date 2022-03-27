using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityAPIPuzzle.Migrations
{
    public partial class AddMenuCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainCategory = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuCategory_MenuCategory_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "MenuCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "706f240d-9ec2-4d92-86a6-8cd0b4c763d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b194a75-1c94-4b55-bbe4-ad8bccf6654b", "AQAAAAEAACcQAAAAELBy3ESk1zf+5aIy0yw7Vk+7KY0w3UXMy30cOhhUzp5y15c0GL6t3XEyMrFySNFWgw==", "b537bb59-cd4e-45bb-a6c6-20eb30b24d2a" });

            migrationBuilder.CreateIndex(
                name: "IX_MenuCategory_ParentCategoryId",
                table: "MenuCategory",
                column: "ParentCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuCategory");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "706f240d-9ec2-4d92-86a6-8cd0b4c763d3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a0b50da-4ce8-46ee-8cea-7a873577361c", "AQAAAAEAACcQAAAAELtLYuwToDfrIWJUfmaj6gHRrl7u9J61ClzCGmYCtePNocp2g5jSIBW9eEnqSX7udA==", "f5cb8268-7cb9-473c-b91c-ca8cbec3ce7b" });
        }
    }
}
