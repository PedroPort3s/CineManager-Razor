using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Models
{
    public class TipoSala
    {
        public int Id{ get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "Tipo de Sala")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "o {0} deve ter entre {1} e {2} caracteres")]
        [Column(TypeName = "varchar(150)")]
        public string Tipo { get; set; }
    }
}
