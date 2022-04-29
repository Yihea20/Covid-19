using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounts_5.Migrations
{
    public partial class AddNewDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaccinationId = table.Column<int>(type: "int", nullable: false),
                    number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doses", x => x.id);
                    table.ForeignKey(
                        name: "FK_Doses_Vaccinations_VaccinationId",
                        column: x => x.VaccinationId,
                        principalTable: "Vaccinations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doses_VaccinationId",
                table: "Doses",
                column: "VaccinationId");
        }
    }
}
