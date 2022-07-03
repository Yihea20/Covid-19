using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounts_5.Migrations
{
    public partial class test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b2c5af4-8eb1-41c7-9439-1c367643a064");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9513378-d259-426c-8629-f183b803cb36");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1802132b-0b2d-499f-88e1-db3017d3f81f", "aa9820a9-b29f-46dd-810f-cf2061536db1", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "44d64636-456f-4f3f-9e64-d7cc2ac556bf", "5f473898-25ee-4711-afe7-97eea3fb67c8", "administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1802132b-0b2d-499f-88e1-db3017d3f81f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44d64636-456f-4f3f-9e64-d7cc2ac556bf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6b2c5af4-8eb1-41c7-9439-1c367643a064", "51c1455a-d644-4d46-90e5-00b360a4e58a", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c9513378-d259-426c-8629-f183b803cb36", "e438ef4e-4567-44c0-9ba5-7f258437678c", "administrator", "ADMINISTRATOR" });
        }
    }
}
