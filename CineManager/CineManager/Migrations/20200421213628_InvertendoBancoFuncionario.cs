using Microsoft.EntityFrameworkCore.Migrations;

namespace CineManager.Migrations
{
    public partial class InvertendoBancoFuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Endereco_EnderecoId",
                table: "Funcionario");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Telefone_TelefoneId",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_EnderecoId",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_TelefoneId",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "TelefoneId",
                table: "Funcionario");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "TipoSala",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Telefone",
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

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Endereco",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_FuncionarioId",
                table: "Telefone",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_FuncionarioId",
                table: "Endereco",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Funcionario_FuncionarioId",
                table: "Endereco",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_Funcionario_FuncionarioId",
                table: "Telefone",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Funcionario_FuncionarioId",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_Funcionario_FuncionarioId",
                table: "Telefone");

            migrationBuilder.DropIndex(
                name: "IX_Telefone_FuncionarioId",
                table: "Telefone");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_FuncionarioId",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Telefone");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Endereco");

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
                name: "EnderecoId",
                table: "Funcionario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TelefoneId",
                table: "Funcionario",
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
                name: "IX_Funcionario_EnderecoId",
                table: "Funcionario",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_TelefoneId",
                table: "Funcionario",
                column: "TelefoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Endereco_EnderecoId",
                table: "Funcionario",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Telefone_TelefoneId",
                table: "Funcionario",
                column: "TelefoneId",
                principalTable: "Telefone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
