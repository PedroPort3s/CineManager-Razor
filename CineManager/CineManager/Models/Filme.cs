using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Models {
    public class Filme {


        public int Id { get; set; }
        
        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "Título")]
        [RegularExpression(@"^[A-Z0-9]+[a-zA-Z0-9""'\s-]*$")]
        [MaxLength(200, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve ter no minimo {1} caracteres")]
        [Column(TypeName = "varchar(200)")]
        public string Titulo { get; set; }


        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "Duração do filme")]
        [Range(20, 500, ErrorMessage = "A {0} tem de estar entre {1} e {2}")]
        [RegularExpression(@"^[0-9]*$")]
        [Column(TypeName = "int")]
        public int Duracao { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "Data de lançamento")]
        [DataType(DataType.Date)]
        [Column(TypeName = "datetime")]
        public DateTime Lancamento { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "Em cartaz até")]
        [DataType(DataType.Date)]
        [Column(TypeName = "datetime")]
        public DateTime EmCartazAte { get; set; }

        [Display(Name = "Tipo do filme")]
        public TipoFilme TipoFilme { get; set; }

        [Display(Name = "Gênero")]
        public Genero Genero { get; set; }
        
        public int GeneroId { get; set; }
        public int TipoFilmeId { get; set; }

    }
}
