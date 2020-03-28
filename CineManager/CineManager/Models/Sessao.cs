using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Models
{
    public class Sessao
    {
        public int Id { get; set; }
      
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Duração da Sessão")]
        [Column(TypeName = "int")]
        public int Duracao_Sessao { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression(@"^[A-Z0-9]+[a-zA-Z0-9""'\s-]*$^ ")]
        [MaxLength(200, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve ter no mínimo {1} caractere")]
        [Column(TypeName = "varchar(200)")]

        public string Filme { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression(@"^[0-9]*$")]
        [Column(TypeName = "int")]
        public int Sala { get; set; }

    }
}
