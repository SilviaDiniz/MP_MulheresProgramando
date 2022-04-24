using Microsoft.EntityFrameworkCore.Migrations;

namespace MP_MulheresProgramando.Migrations
{
    public partial class CriandoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programadoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDev = table.Column<string>(type: "varchar(80)", nullable: false),
                    LinguagemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programadoras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programadoras_Linguagens_LinguagemId",
                        column: x => x.LinguagemId,
                        principalTable: "Linguagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programadoras_LinguagemId",
                table: "Programadoras",
                column: "LinguagemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programadoras");
        }
    }
}
