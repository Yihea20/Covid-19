using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounts_5.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Newss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationCenters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vaccinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DosesNumber = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowedAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vaccinationCenter_Vaccinations",
                columns: table => new
                {
                    vaccinationId = table.Column<int>(type: "int", nullable: false),
                    vaccinationCenterId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaccinationCenter_Vaccinations", x => new { x.vaccinationId, x.vaccinationCenterId });
                    table.ForeignKey(
                        name: "FK_vaccinationCenter_Vaccinations_VaccinationCenters_vaccinationCenterId",
                        column: x => x.vaccinationCenterId,
                        principalTable: "VaccinationCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vaccinationCenter_Vaccinations_Vaccinations_vaccinationId",
                        column: x => x.vaccinationId,
                        principalTable: "Vaccinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vaccinationCenter_Vaccinations_vaccinationCenterId",
                table: "vaccinationCenter_Vaccinations",
                column: "vaccinationCenterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Newss");

            migrationBuilder.DropTable(
                name: "vaccinationCenter_Vaccinations");

            migrationBuilder.DropTable(
                name: "VaccinationCenters");

            migrationBuilder.DropTable(
                name: "Vaccinations");
        }
    }
}
