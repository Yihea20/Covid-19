using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounts_5.Migrations
{
    public partial class test9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_People_VaccinationCenters",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
