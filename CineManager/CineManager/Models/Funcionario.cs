using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineManager.Models
{
    public class Funcionario
    {
        public Funcionario() {
            ListaEnderecos = new List<Endereco>();
            ListaTelefones = new List<Telefone>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Nome completo")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        [Column(TypeName = "varchar(100)")]
        public string NomeCompleto{ get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Setor")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        [Column(TypeName = "varchar(100)")]
        public string Setor { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression(@"^(\d{14})$", ErrorMessage = "O campo {0} deve conter 11 dígitos")]
        [Column(TypeName = "bigint")]
        public long Cpf { get; set; }

        [Display(Name = "RG")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression(@"^(\d{9})$", ErrorMessage = "O campo {0} deve conter 9 dígitos")]
        [Column(TypeName = "bigint")]
        public long Rg { get; set; }

        [Display(Name = "Salário")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression(@"^(\d{3,6}(\,?\d{1,2}))$", ErrorMessage = "deu ruim ainda "/*"O campo {0} deve conter de 3 a 8 dígitos"*/)]
        [Column(TypeName = "varchar(12)")] 
        public string Salario { get; set; }

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

        public List<Telefone> ListaTelefones { get; set; }
        public List<Endereco> ListaEnderecos { get; set; }

        [NotMapped]
        public Telefone Telefone { get; set; }
        [NotMapped]
        [Display(Name = "Endereço")]
        public Endereco Endereco { get; set; }
        [NotMapped]
        public int TelefoneId { get; set; }
        [NotMapped]
        public int EnderecoId { get; set; }
    }
}
