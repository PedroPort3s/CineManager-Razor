using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineManager.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Nome completo")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        [Column(TypeName = "varchar(100)")]
        public string NomeCompleto{ get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "E-Mail")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        [Column(TypeName = "varchar(100)")]
        public string Setor { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "O campo {0} deve conter 11 dígitos")]
        [Column(TypeName = "bigint")]
        public long Cpf { get; set; }

        [Display(Name = "RG")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression(@"^(\d{8,9})$", ErrorMessage = "O campo {0} deve conter 9 dígitos")]
        [Column(TypeName = "bigint")]
        public long Rg { get; set; }

        [Display(Name = "Salário")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(100, 100000, ErrorMessage = "O campo {0} tem de estar entre {1} e {2}")]
        [RegularExpression(@"^(\d{3,6})$", ErrorMessage = "O campo {0} deve conter de 3 a 6 dígitos")]
        [Column(TypeName = "decimal(12,3)")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Cargo")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        [Column(TypeName = "varchar(100)")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Turno")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        [Column(TypeName = "varchar(100)")]
        public string Turno { get; set; }

        public Telefone Telefone { get; set; }

        [Display(Name = "Endereço")]
        public Endereco Endereco { get; set; }
        public int TelefoneId { get; set; }
        public int EnderecoId { get; set; }
    }
}
