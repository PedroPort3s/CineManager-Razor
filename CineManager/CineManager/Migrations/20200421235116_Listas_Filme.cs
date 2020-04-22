using Microsoft.EntityFrameworkCore.Migrations;

namespace CineManager.Migrations
{
    public partial class Listas_Filme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Generos_GeneroId",
                table: "Filme");

            migrationBuilder.DropForeignKey(
                name: "FK_Filme_TipoFilmes_TipoFilmeId",
                table: "Filme");

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

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "TipoSala",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<int>(
                name: "FilmeId",
                table: "TipoFilmes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilmeId",
                table: "Generos",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Turno",
                table: "Funcionario",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "NomeCompleto",
                table: "Funcionario",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Endereco",
                type: "varchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)");

            migrationBuilder.CreateIndex(
                name: "IX_TipoFilmes_FilmeId",
                table: "TipoFilmes",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_Generos_FilmeId",
                table: "Generos",
                column: "FilmeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Generos_Filme_FilmeId",
                table: "Generos",
                column: "FilmeId",
                principalTable: "Filme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoFilmes_Filme_FilmeId",
                table: "TipoFilmes",
                column: "FilmeId",
                principalTable: "Filme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Generos_Filme_FilmeId",
                table: "Generos");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoFilmes_Filme_FilmeId",
                table: "TipoFilmes");

            migrationBuilder.DropIndex(
                name: "IX_TipoFilmes_FilmeId",
                table: "TipoFilmes");

            migrationBuilder.DropIndex(
                name: "IX_Generos_FilmeId",
                table: "Generos");

            migrationBuilder.DropColumn(
                name: "FilmeId",
                table: "TipoFilmes");

            migrationBuilder.DropColumn(
                name: "FilmeId",
                table: "Generos");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "TipoSala",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Turno",
                table: "Funcionario",
                type: "varchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "NomeCompleto",
                table: "Funcionario",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Filme",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoFilmeId",
                table: "Filme",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Endereco",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldMaxLength: 8);

            migrationBuilder.CreateIndex(
                name: "IX_Filme_GeneroId",
                table: "Filme",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Filme_TipoFilmeId",
                table: "Filme",
                column: "TipoFilmeId");

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
    }
}
