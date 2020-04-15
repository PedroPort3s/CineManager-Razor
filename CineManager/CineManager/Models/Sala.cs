using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Models
{
    public class Sala
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Nº de Poltronas")]
        [Range(1, 120, ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [RegularExpression(@"^(\d{1,3})$", ErrorMessage = "O campo {0} deve conter de 1 a 3 dígitos.")]
        [Column(TypeName = "int")]
        public int NumPoltrona { get; set; }
        public int TipoSalaId { get; set; }
        public TipoSala TipoSala { get; set; }
    }
}
