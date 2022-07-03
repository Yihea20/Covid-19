using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounts_5.Migrations
{
    public partial class test11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: "16e9b9f4-68c7-492e-b785-148bba2ac167");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f3e0b9b-ba39-4b83-a2f2-42e40391f31c");

            migrationBuilder.DropColumn(
                name: "vaccinationId",
                table: "People_VaccinationCenters");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b3f542d-ce6d-4146-9bf6-3bf9fe64fb88", "e9e75938-a8a6-4a22-b982-74de48fcc701", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e24392ca-8b2e-4664-a64d-49dc7ee22918", "c08bc17d-463d-49f5-b27e-57922d07df6c", "administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b3f542d-ce6d-4146-9bf6-3bf9fe64fb88");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e24392ca-8b2e-4664-a64d-49dc7ee22918");

            migrationBuilder.AddColumn<int>(
                name: "vaccinationId",
                table: "People_VaccinationCenters",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_People_VaccinationCenters_Vaccinations_vaccinationId",
                table: "People_VaccinationCenters",
                column: "vaccinationId",
                principalTable: "Vaccinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
