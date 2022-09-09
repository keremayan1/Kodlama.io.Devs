using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class AddProgrammingLanguageTechnologies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgrammingLanguageTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgrammingLanguageId = table.Column<int>(type: "int", nullable: false),
                    ProgrammingLanguageTechnologyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguageTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgrammingLanguageTechnologies_ProgrammingLanguages_ProgrammingLanguageId",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguageTechnologies",
                columns: new[] { "Id", "ProgrammingLanguageId", "ProgrammingLanguageTechnologyName" },
                values: new object[] { 1, 3, "MVC" });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Next.js" });

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingLanguageTechnologies_ProgrammingLanguageId",
                table: "ProgrammingLanguageTechnologies",
                column: "ProgrammingLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgrammingLanguageTechnologies");

            migrationBuilder.DeleteData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
