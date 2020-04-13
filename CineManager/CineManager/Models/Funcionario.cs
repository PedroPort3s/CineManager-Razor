using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineManager.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "Nome Completo")]
        [MaxLength(200, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve ter no minimo {1} caracteres")]
        [Column(TypeName = "varchar(200)")] 
        public string NomeCompleto{ get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Column(TypeName = "varchar(100)")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve ter no minimo {1} caracter")]
        public string Setor { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "CPF")]
        [Column(TypeName = "bigint")]
        [Range(11, 11, ErrorMessage = "o campo {0} tem de ter {11} caracteres")]
        public long Cpf { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "RG")]
        [Column(TypeName = "bigint")]
        [Range(9, 9, ErrorMessage = "o campo {0} tem de ter {1} caracteres")]
        public long Rg { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "Salário")]
        [Column(TypeName = "decimal(12,3)")]
        [RegularExpression("^[0-9]*$")]   
        [Range(100, 100000, ErrorMessage = "o campo {0} tem de estar entre {1} e {2}")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Column(TypeName = "varchar(100)")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve ter no minimo {1} caracter")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Column(TypeName = "varchar(80)")]
        [MaxLength(80, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve ter no minimo {1} caracter")]
        public string Turno { get; set; }

        public Telefone Telefone { get; set; }

        [Display(Name = "Endereço")]
        public Endereco Endereco { get; set; }
        public int TelefoneId { get; set; }
        public int EnderecoId { get; set; }
    }
}
