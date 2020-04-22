using Microsoft.EntityFrameworkCore.Migrations;

namespace CineManager.Migrations
{
    public partial class InvertendoBancoFornecedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedor_Email_EmailId",
                table: "Fornecedor");

            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedor_Endereco_EnderecoId",
                table: "Fornecedor");

            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedor_Telefone_TelefoneId",
                table: "Fornecedor");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedor_EmailId",
                table: "Fornecedor");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedor_EnderecoId",
                table: "Fornecedor");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedor_TelefoneId",
                table: "Fornecedor");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "Fornecedor");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Fornecedor");

            migrationBuilder.DropColumn(
                name: "TelefoneId",
                table: "Fornecedor");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "TipoSala",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<int>(
                name: "FornecedorId",
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
                name: "FornecedorId",
                table: "Endereco",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FornecedorId",
                table: "Email",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_FornecedorId",
                table: "Telefone",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_FornecedorId",
                table: "Endereco",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Email_FornecedorId",
                table: "Email",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Email_Fornecedor_FornecedorId",
                table: "Email",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Fornecedor_FornecedorId",
                table: "Endereco",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_Fornecedor_FornecedorId",
                table: "Telefone",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Email_Fornecedor_FornecedorId",
                table: "Email");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Fornecedor_FornecedorId",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_Fornecedor_FornecedorId",
                table: "Telefone");

            migrationBuilder.DropIndex(
                name: "IX_Telefone_FornecedorId",
                table: "Telefone");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_FornecedorId",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Email_FornecedorId",
                table: "Email");

            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "Telefone");

            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "Email");

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
                name: "EmailId",
                table: "Fornecedor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Fornecedor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TelefoneId",
                table: "Fornecedor",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Endereco",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldMaxLength: 8);

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_EmailId",
                table: "Fornecedor",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_EnderecoId",
                table: "Fornecedor",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_TelefoneId",
                table: "Fornecedor",
                column: "TelefoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedor_Email_EmailId",
                table: "Fornecedor",
                column: "EmailId",
                principalTable: "Email",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedor_Endereco_EnderecoId",
                table: "Fornecedor",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedor_Telefone_TelefoneId",
                table: "Fornecedor",
                column: "TelefoneId",
                principalTable: "Telefone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
