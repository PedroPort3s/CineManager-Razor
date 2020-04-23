using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Models
{
    public class Genero
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Nome")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        [Column(TypeName = "varchar(100)")]
        public string Nome{ get; set; }
    }
}
