using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Models
{
    public class TipoFilme
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Tipo de Filme")]
        //Expressão regular que permite a entrada de números, letras (sem acentuação), traço e espaço.
        [RegularExpression(@"^[\w]+[\w\s-]*$", ErrorMessage = "O campo {0} não pode conter acentuação ou caracteres especiais.")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres.")]
        [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caractere.")]
        [Column(TypeName = "varchar(100)")]
        public string NomeTipoFilme { get; set; }
    }
}
