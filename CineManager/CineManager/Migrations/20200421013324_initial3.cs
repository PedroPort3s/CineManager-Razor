using Microsoft.EntityFrameworkCore.Migrations;

namespace CineManager.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoFilmeId",
                table: "GeneroFilmes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GeneroFilmes_TipoFilmeId",
                table: "GeneroFilmes",
                column: "TipoFilmeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneroFilmes_TipoFilmes_TipoFilmeId",
                table: "GeneroFilmes",
                column: "TipoFilmeId",
                principalTable: "TipoFilmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneroFilmes_TipoFilmes_TipoFilmeId",
                table: "GeneroFilmes");

            migrationBuilder.DropIndex(
                name: "IX_GeneroFilmes_TipoFilmeId",
                table: "GeneroFilmes");

            migrationBuilder.DropColumn(
                name: "TipoFilmeId",
                table: "GeneroFilmes");
        }
    }
}
