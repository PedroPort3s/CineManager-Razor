using Microsoft.EntityFrameworkCore.Migrations;

namespace CineManager.Migrations
{
    public partial class RelacionandoFilme2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Genero_GeneroId",
                table: "Filme");

            migrationBuilder.DropForeignKey(
                name: "FK_Filme_TipoFilme_TipoFilmeId",
                table: "Filme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoFilme",
                table: "TipoFilme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genero",
                table: "Genero");

            migrationBuilder.RenameTable(
                name: "TipoFilme",
                newName: "TipoFilmes");

            migrationBuilder.RenameTable(
                name: "Genero",
                newName: "Generos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoFilmes",
                table: "TipoFilmes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Generos",
                table: "Generos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Filme_Generos_GeneroId",
                table: "Filme",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filme_TipoFilmes_TipoFilmeId",
                table: "Filme",
                column: "TipoFilmeId",
                principalTable: "TipoFilmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Generos_GeneroId",
                table: "Filme");

            migrationBuilder.DropForeignKey(
                name: "FK_Filme_TipoFilmes_TipoFilmeId",
                table: "Filme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoFilmes",
                table: "TipoFilmes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Generos",
                table: "Generos");

            migrationBuilder.RenameTable(
                name: "TipoFilmes",
                newName: "TipoFilme");

            migrationBuilder.RenameTable(
                name: "Generos",
                newName: "Genero");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoFilme",
                table: "TipoFilme",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genero",
                table: "Genero",
                column: "Id");

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
    }
}
