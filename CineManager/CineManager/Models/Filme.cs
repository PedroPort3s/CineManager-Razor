using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Models {
    public class Filme {

        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Título")]
        [RegularExpression(@"^(?=.{1,200}$).*", ErrorMessage = "O campo {0} deve conter entre 1 e 200 caracteres")]
        [Column(TypeName = "varchar(200)")]
        public string Titulo { get; set; }

        [Display(Name = "Duração")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Column(TypeName = "int")]
        [Range(20, 500, ErrorMessage = "O campo {0} deve conter entre {1} e {2} caracteres.")]
        [RegularExpression(@"^(\d{1,3})$", ErrorMessage = "O campo {0} deve conter de 1 a 3 dígitos.")]
        public int Duracao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Data de lançamento")]
        [DataType(DataType.Date)]
        [Column(TypeName = "datetime")]
        //Verificar. DataFormatString não está funcionando corretamente
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Lancamento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Em cartaz até")]
        [DataType(DataType.Date)]
        [Column(TypeName = "datetime")]
        //Verificar. DataFormatString não está funcionando corretamente
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EmCartazAte { get; set; }

        public List<FilmeGenero> Generos { get; set; } = new List<FilmeGenero>();
        public List<FilmeTipoFilme> TiposFilme { get; set; } = new List<FilmeTipoFilme>();

        [NotMapped]
        public string ListaGenerosJoin { get; set; }

        [NotMapped]
        [Display(Name = "Tipo do filme")]
        public TipoFilme TipoFilme { get; set; }

        [NotMapped]
        [Display(Name = "Gênero")]
        public Genero Genero { get; set; }
        
        [NotMapped]
        public int GeneroId { get; set; }

        [NotMapped]
        public int TipoFilmeId { get; set; }
    }
}
