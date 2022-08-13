using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounts_5.Migrations
{
    public partial class test12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b3f542d-ce6d-4146-9bf6-3bf9fe64fb88");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e24392ca-8b2e-4664-a64d-49dc7ee22918");

            migrationBuilder.AddColumn<string>(
                name: "Parag",
                table: "Newss",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "63fb1502-e1c6-4a76-876d-34e086c6b368", "87ca20b8-5555-4a68-9e80-c7984326838a", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "38a04949-4d72-4664-bc0f-a6e54a266d6d", "b1d0abf0-eca7-475b-859e-76864fe7e680", "administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38a04949-4d72-4664-bc0f-a6e54a266d6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63fb1502-e1c6-4a76-876d-34e086c6b368");

            migrationBuilder.DropColumn(
                name: "Parag",
                table: "Newss");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b3f542d-ce6d-4146-9bf6-3bf9fe64fb88", "e9e75938-a8a6-4a22-b982-74de48fcc701", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e24392ca-8b2e-4664-a64d-49dc7ee22918", "c08bc17d-463d-49f5-b27e-57922d07df6c", "administrator", "ADMINISTRATOR" });
        }
    }
}
