using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Models {
    public class Filme {


        public int Id { get; set; }
        
        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public int Duracao { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public DateTime Lancamento { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public DateTime EmCartazAte { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public string TipoFilme { get; set; }
    }
}
