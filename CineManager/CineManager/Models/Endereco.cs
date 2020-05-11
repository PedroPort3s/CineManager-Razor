using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Models
{
    public class Endereco
    {   
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Tipo do logradouro")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        [Column(TypeName = "varchar(100)")]
        public string TipoLogradouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Nome do logradouro")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        [Column(TypeName = "varchar(100)")]
        public string NomeLogradouro { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Column(TypeName = "int")]
        [RegularExpression(@"^(\d{1,6})$", ErrorMessage = "O campo {0} deve conter de 1 a 6 dígitos")]
        public int Numero { get; set; }

        [Display(Name = "Complemento")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        [Column(TypeName = "varchar(100)")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "CEP")]
        [MaxLength(10, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        [Column(TypeName = "varchar(8)")]
        //[RegularExpression(@"^(\d{9})$", ErrorMessage = "O campo {0} deve conter 8 dígitos")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Bairro")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        [Column(TypeName = "varchar(100)")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Cidade")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        [Column(TypeName = "varchar(100)")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Estado")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        [Column(TypeName = "varchar(100)")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Pais")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        [Column(TypeName = "varchar(100)")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Tipo de endereço")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        [Column(TypeName = "varchar(100)")]
        public string TipoEndereco { get; set; }
    }
}
