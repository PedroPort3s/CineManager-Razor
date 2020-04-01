using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CineManager.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório.")]
        [Display(Name = "Nome da Empresa")]
        [RegularExpression(@"^[A-Z0-9]+[a-zA-Z0-9""'\s-]*$", ErrorMessage = "A primeira letra deve ser maiúscula e não podem haver acentos.")]
        [MaxLength(40, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [MinLength(1, ErrorMessage = "O campo {0} deve ter no minimo {1} caracteres.")]
        public string NomeDaEmpresa { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "Telefone")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "apenas números contendo entre 8 e 20 caracteres")]
        [MaxLength(20, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [MinLength(8, ErrorMessage = "O campo {0} deve ter no minimo {1} caracteres.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório.")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "deve corresponder ao formato de email (ex: nome@email.com)")]
        [MaxLength(40, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [MinLength(1, ErrorMessage = "O campo {0} deve ter no minimo {1} caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório.")]
        [Display(Name = "Endereço")]
        [RegularExpression(@"^[A-Z0-9]+[a-zA-Z0-9""'\s-]*$", ErrorMessage = "A primeira letra deve ser maiúscula e não podem haver acentos.")]
        [MaxLength(20, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [MinLength(1, ErrorMessage = "O campo {0} deve ter no minimo {1} caracteres.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório.")]
        [Display(Name = "Nome do Responsável")]
        [RegularExpression(@"^[A-Z0-9]+[a-zA-Z0-9""'\s-]*$", ErrorMessage = "A primeira letra deve ser maiúscula e não podem haver acentos.")]
        [MaxLength(40, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [MinLength(1, ErrorMessage = "O campo {0} deve ter no minimo {1} caracteres.")]
        public string NomeResponsavel { get; set; }
    }
}