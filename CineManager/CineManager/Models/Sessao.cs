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
        // Validação para campo obrigatório
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Duração da Sessão")]
        //Expressão regular para permitir somente a entrada de números, e também limitar para que seja de 1 a 3 dígitos
        [RegularExpression(@"^(\d{1,3})$", ErrorMessage = "O campo {0} deve conter de 1 a 3 dígitos.")]
        [Range(30, 510, ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Column(TypeName = "int")]
        public int Duracao_Sessao { get; set; }
        public Filme Filme { get; set; }
        public Sala Sala { get; set; }
        public int FilmeId { get; set; }
        public int SalaId { get; set; }
    }
}
