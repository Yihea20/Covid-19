using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounts_5.Migrations
{
    public partial class test6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1802132b-0b2d-499f-88e1-db3017d3f81f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44d64636-456f-4f3f-9e64-d7cc2ac556bf");

            migrationBuilder.AddColumn<DateTime>(
                name: "dateTime",
                table: "Newss",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64e25b11-555c-4f51-8f9e-7a261c04046c", "210ee100-ceca-4e88-b748-c5c1f050f09f", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3f8e2cd-2439-47c0-a71c-e7b2045e6e67", "a28ec8c8-96ed-4267-b176-9888e836ac72", "administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64e25b11-555c-4f51-8f9e-7a261c04046c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3f8e2cd-2439-47c0-a71c-e7b2045e6e67");

            migrationBuilder.DropColumn(
                name: "dateTime",
                table: "Newss");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1802132b-0b2d-499f-88e1-db3017d3f81f", "aa9820a9-b29f-46dd-810f-cf2061536db1", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "44d64636-456f-4f3f-9e64-d7cc2ac556bf", "5f473898-25ee-4711-afe7-97eea3fb67c8", "administrator", "ADMINISTRATOR" });
        }
    }
}
