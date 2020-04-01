using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Models
{
    public class Telefone
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "Tipo do filme")]
        [RegularExpression(@"^[A-Z0-9]+[a-zA-Z0-9""'\s-]*$")]
        [MaxLength(20, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve ter no minimo {1} caracteres")]
        [Column(TypeName = "varchar(20)")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "DDD")]
        [Column(TypeName = "int")]
        public int DDD { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "Numero")]
        [Column(TypeName = "bigint")]
        public long Numero { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "DDI")]
        [Column(TypeName = "int")]
        public int DDI { get; set; }
    }
}
