using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounts_5.Migrations
{
    public partial class test8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People_Vaccinations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27682245-9a4c-49c7-9eda-f0226b9ca2ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "998735aa-c539-4690-8ace-8c8c97e3704c");

            migrationBuilder.AddColumn<int>(
                name: "vaccinationId",
                table: "People_VaccinationCenters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bafeb430-f4db-4ffd-91fb-0b4b7582a9bc", "9bc28387-6ca1-4981-a674-2aa0e00b8e88", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d26f97f6-2616-47a7-be8d-38b7ab7395d9", "2506a893-0a80-4dbd-a949-031df8c9b684", "administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_People_VaccinationCenters_vaccinationId",
                table: "People_VaccinationCenters",
                column: "vaccinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_VaccinationCenters_Vaccinations_vaccinationId",
                table: "People_VaccinationCenters",
                column: "vaccinationId",
                principalTable: "Vaccinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_VaccinationCenters_Vaccinations_vaccinationId",
                table: "People_VaccinationCenters");

            migrationBuilder.DropIndex(
                name: "IX_People_VaccinationCenters_vaccinationId",
                table: "People_VaccinationCenters");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bafeb430-f4db-4ffd-91fb-0b4b7582a9bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d26f97f6-2616-47a7-be8d-38b7ab7395d9");

            migrationBuilder.DropColumn(
                name: "vaccinationId",
                table: "People_VaccinationCenters");

            migrationBuilder.CreateTable(
                name: "People_Vaccinations",
                columns: table => new
                {
                    VaccinationId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                values: new object[] { "998735aa-c539-4690-8ace-8c8c97e3704c", "9fb27f9e-23f6-406d-973d-274e5eb7e19e", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "27682245-9a4c-49c7-9eda-f0226b9ca2ce", "b9937aac-4a07-4de1-ba25-7547bacd561f", "administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_People_Vaccinations_PersonId",
                table: "People_Vaccinations",
                column: "PersonId");
        }
    }
}
