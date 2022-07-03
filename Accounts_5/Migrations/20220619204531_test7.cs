using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounts_5.Migrations
{
    public partial class test7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64e25b11-555c-4f51-8f9e-7a261c04046c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3f8e2cd-2439-47c0-a71c-e7b2045e6e67");

            migrationBuilder.AddColumn<DateTime>(
                name: "dateTime",
                table: "Vaccinations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dateTime",
                table: "VaccinationCenters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dateTime",
                table: "vaccinationCenter_Vaccinations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dateTime",
                table: "People_Vaccinations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dateTime",
                table: "People_VaccinationCenters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "998735aa-c539-4690-8ace-8c8c97e3704c", "9fb27f9e-23f6-406d-973d-274e5eb7e19e", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "27682245-9a4c-49c7-9eda-f0226b9ca2ce", "b9937aac-4a07-4de1-ba25-7547bacd561f", "administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27682245-9a4c-49c7-9eda-f0226b9ca2ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "998735aa-c539-4690-8ace-8c8c97e3704c");

            migrationBuilder.DropColumn(
                name: "dateTime",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "dateTime",
                table: "VaccinationCenters");

            migrationBuilder.DropColumn(
                name: "dateTime",
                table: "vaccinationCenter_Vaccinations");

            migrationBuilder.DropColumn(
                name: "dateTime",
                table: "People_Vaccinations");

            migrationBuilder.DropColumn(
                name: "dateTime",
                table: "People_VaccinationCenters");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64e25b11-555c-4f51-8f9e-7a261c04046c", "210ee100-ceca-4e88-b748-c5c1f050f09f", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3f8e2cd-2439-47c0-a71c-e7b2045e6e67", "a28ec8c8-96ed-4267-b176-9888e836ac72", "administrator", "ADMINISTRATOR" });
        }
    }
}
