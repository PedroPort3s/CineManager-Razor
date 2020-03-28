using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Models
{
    public class Sala
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public int NumPoltrona { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public string TipoSala { get; set; }
    }
}
