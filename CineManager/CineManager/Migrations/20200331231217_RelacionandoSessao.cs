using Microsoft.EntityFrameworkCore.Migrations;

namespace CineManager.Migrations
{
    public partial class RelacionandoSessao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Filme",
                table: "Sessao");

            migrationBuilder.DropColumn(
                name: "Sala",
                table: "Sessao");

            migrationBuilder.AddColumn<int>(
                name: "FilmeId",
                table: "Sessao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalaId",
                table: "Sessao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_FilmeId",
                table: "Sessao",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_SalaId",
                table: "Sessao",
                column: "SalaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessao_Filme_FilmeId",
                table: "Sessao",
                column: "FilmeId",
                principalTable: "Filme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessao_Sala_SalaId",
                table: "Sessao",
                column: "SalaId",
                principalTable: "Sala",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessao_Filme_FilmeId",
                table: "Sessao");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessao_Sala_SalaId",
                table: "Sessao");

            migrationBuilder.DropIndex(
                name: "IX_Sessao_FilmeId",
                table: "Sessao");

            migrationBuilder.DropIndex(
                name: "IX_Sessao_SalaId",
                table: "Sessao");

            migrationBuilder.DropColumn(
                name: "FilmeId",
                table: "Sessao");

            migrationBuilder.DropColumn(
                name: "SalaId",
                table: "Sessao");

            migrationBuilder.AddColumn<string>(
                name: "Filme",
                table: "Sessao",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Sala",
                table: "Sessao",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
