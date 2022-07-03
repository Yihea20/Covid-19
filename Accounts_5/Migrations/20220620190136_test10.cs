using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounts_5.Migrations
{
    public partial class test10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonVaccinationCenter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People_VaccinationCenters",
                table: "People_VaccinationCenters");

            migrationBuilder.DropIndex(
                name: "IX_People_VaccinationCenters_VaccinationCenterId",
                table: "People_VaccinationCenters");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07976e1f-b407-4804-b1b3-d55bcf09d3b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61e35f8d-d4a6-457b-abe7-1090a3367d57");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People_VaccinationCenters",
                table: "People_VaccinationCenters",
                columns: new[] { "VaccinationCenterId", "PersonId" });

            migrationBuilder.CreateTable(
                name: "People_Vaccinations",
                columns: table => new
                {
                    PersonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VaccinationId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People_Vaccinations", x => new { x.VaccinationId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_People_Vaccinations_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_People_Vaccinations_Vaccinations_VaccinationId",
                        column: x => x.VaccinationId,
                        principalTable: "Vaccinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5f3e0b9b-ba39-4b83-a2f2-42e40391f31c", "d6c5b2df-932b-4168-8af9-bf9bc05f9eed", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "16e9b9f4-68c7-492e-b785-148bba2ac167", "f6aadc70-0df8-4fdd-9d50-6bfe096a96ce", "administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_People_VaccinationCenters_vaccinationId",
                table: "People_VaccinationCenters",
                column: "vaccinationId");

            migrationBuilder.CreateIndex(
                name: "IX_People_Vaccinations_PersonId",
                table: "People_Vaccinations",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People_Vaccinations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People_VaccinationCenters",
                table: "People_VaccinationCenters");

            migrationBuilder.DropIndex(
                name: "IX_People_VaccinationCenters_vaccinationId",
                table: "People_VaccinationCenters");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16e9b9f4-68c7-492e-b785-148bba2ac167");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f3e0b9b-ba39-4b83-a2f2-42e40391f31c");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People_VaccinationCenters",
                table: "People_VaccinationCenters",
                columns: new[] { "vaccinationId", "PersonId" });

            migrationBuilder.CreateTable(
                name: "PersonVaccinationCenter",
                columns: table => new
                {
                    PersonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VaccinationCentersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonVaccinationCenter", x => new { x.PersonId, x.VaccinationCentersId });
                    table.ForeignKey(
                        name: "FK_PersonVaccinationCenter_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonVaccinationCenter_VaccinationCenters_VaccinationCentersId",
                        column: x => x.VaccinationCentersId,
                        principalTable: "VaccinationCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "61e35f8d-d4a6-457b-abe7-1090a3367d57", "7fb9ee8a-ebbd-4161-a587-d48097a97c76", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "07976e1f-b407-4804-b1b3-d55bcf09d3b7", "187cc2bc-140c-4425-afe3-27a4ade29baf", "administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_People_VaccinationCenters_VaccinationCenterId",
                table: "People_VaccinationCenters",
                column: "VaccinationCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonVaccinationCenter_VaccinationCentersId",
                table: "PersonVaccinationCenter",
                column: "VaccinationCentersId");
        }
    }
}
