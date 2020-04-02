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
        public Filme Filme { get; set; }
        public Sala Sala { get; set; }
        public int FilmeId { get; set; }
        public int SalaId { get; set; }
    }
}
