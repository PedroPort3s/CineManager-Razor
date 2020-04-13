using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Models {
    public class Telefone {
        public int Id { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "Tipo de número")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve ter no minimo {1} caracteres")]
        [Column(TypeName = "varchar(100)")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "DDD")]
        [Column(TypeName = "int")]
        [Range(10, 99, ErrorMessage = "O campo {0} precisa estar entre {1} e {2}")]

        public int DDD { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "Número")]
        [Column(TypeName = "bigint")]
        [Range(10000000,999999999,ErrorMessage = "Insira um número válido")]
        public long Numero { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "DDI")]
        [Column(TypeName = "int")]
        public int DDI { get; set; }
    }
}
