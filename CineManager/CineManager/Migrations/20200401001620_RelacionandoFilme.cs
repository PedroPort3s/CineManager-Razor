using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CineManager.Migrations
{
    public partial class RelacionandoFilme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Filme");

            migrationBuilder.DropColumn(
                name: "TipoFilme",
                table: "Filme");

            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Filme",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoFilmeId",
                table: "Filme",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoFilme",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeTipoFilme = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoFilme", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filme_GeneroId",
                table: "Filme",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Filme_TipoFilmeId",
                table: "Filme",
                column: "TipoFilmeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filme_Genero_GeneroId",
                table: "Filme",
                column: "GeneroId",
                principalTable: "Genero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filme_TipoFilme_TipoFilmeId",
                table: "Filme",
                column: "TipoFilmeId",
                principalTable: "TipoFilme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Genero_GeneroId",
                table: "Filme");

            migrationBuilder.DropForeignKey(
                name: "FK_Filme_TipoFilme_TipoFilmeId",
                table: "Filme");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "TipoFilme");

            migrationBuilder.DropIndex(
                name: "IX_Filme_GeneroId",
                table: "Filme");

            migrationBuilder.DropIndex(
                name: "IX_Filme_TipoFilmeId",
                table: "Filme");

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Filme");

            migrationBuilder.DropColumn(
                name: "TipoFilmeId",
                table: "Filme");

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Filme",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoFilme",
                table: "Filme",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
