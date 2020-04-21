using Microsoft.EntityFrameworkCore.Migrations;

namespace CineManager.Migrations
{
    public partial class initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoFilmes_Filme_FilmeId",
                table: "TipoFilmes");

            migrationBuilder.DropIndex(
                name: "IX_TipoFilmes_FilmeId",
                table: "TipoFilmes");

            migrationBuilder.DropColumn(
                name: "FilmeId",
                table: "TipoFilmes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilmeId",
                table: "TipoFilmes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoFilmes_FilmeId",
                table: "TipoFilmes",
                column: "FilmeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoFilmes_Filme_FilmeId",
                table: "TipoFilmes",
                column: "FilmeId",
                principalTable: "Filme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
