using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineManager.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name ="Nome Completo")]
        [Column(TypeName = "varchar(100)")]
        [RegularExpression(@"^[A-Z0-9]+[a-zA-Z0-9""'\s-]*$^ ")]
        [Range(0, 100, ErrorMessage = "O {0} tem de estar entre {1} e {2} caracteres")]
        public string NomeCompleto{ get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "Endereço")]
        [Column(TypeName = "varchar(80)")]
        [Range(1, 80, ErrorMessage = "O {0} tem de estar entre {1} e {2} caracteres")]
        [RegularExpression(@"^[A-Z0-9]+[a-zA-Z0-9""'\s-]*$^ ")]
        public string Endereco{ get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Column(TypeName = "varchar(20)")]
        [RegularExpression("^[0-9]*$")]
        [Range(8, 20, ErrorMessage = "O {0} tem de estar entre {1} e {2} caracteres")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Column(TypeName = "varchar(30)")]
        [Range(0, 30, ErrorMessage = "O {0} tem de estar entre {1} e {2} caracteres")]
        [RegularExpression(@"^[A-Z0-9]+[a-zA-Z0-9""'\s-]*$^ ")]
        public string Setor { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "CPF")]
        [Column(TypeName = "bigint")]
        [RegularExpression("^[0-9]*$")]
        [Range(11, 11, ErrorMessage = "O {0} deve ser de 11 caracteres")]
        public long Cpf { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "RG")]
        [Column(TypeName = "bigint")]
        [RegularExpression("^[0-9]*$")]
        [Range(8, 11, ErrorMessage = "O {0} tem de estar entre {1} e {2} caracteres")]
        public long Rg { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "Salário")]
        [Column(TypeName = "decimal(12,3)")]
        [RegularExpression("^[0-9]*$")]
        [Range(1, 15, ErrorMessage = "O {0} tem de estar entre {1} e {2} caracteres")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Column(TypeName = "varchar(30)")]
        [Range(1, 30, ErrorMessage = "O {0} tem de estar entre {1} e {2} caracteres")]
        [RegularExpression(@"^[A-Z0-9]+[a-zA-Z0-9""'\s-]*$^ ")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Column(TypeName = "varchar(15)")]
        [Range(1, 15, ErrorMessage = "O {0} tem de estar entre {1} e {2} caracteres")]
        [RegularExpression(@"^[A-Z0-9]+[a-zA-Z0-9""'\s-]*$^ ")]
        public string Turno { get; set; }
    }
}
