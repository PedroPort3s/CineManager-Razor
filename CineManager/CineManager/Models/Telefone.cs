using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Models {
    public class Telefone {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Tipo de número")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres.")]
        [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caractere.")]
        [Column(TypeName = "varchar(100)")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "DDD")]
        [RegularExpression(@"^(\d{2})$", ErrorMessage = "O campo {0} deve conter no máximo 2 dígitos.")]
        [Column(TypeName = "int")]
        public int DDD { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Número")]
        [RegularExpression(@"^(\d{8,9})$", ErrorMessage = "O campo {0} deve conter de 8 a 9 dígitos.")]
        [Column(TypeName = "bigint")]
        public long Numero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "DDI")]
        [RegularExpression(@"^(\d{1,3})$", ErrorMessage = "O campo {0} deve conter entre 1 e 3 dígitos.")]
        [Column(TypeName = "int")]
        public int DDI { get; set; }
    }
}
