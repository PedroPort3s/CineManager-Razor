using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Models
{
    public class Endereco
    {   
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Tipo do logradouro")]
        //Regex para substituir validações de min e max length
        [RegularExpression(@"^(?=.{1,100}$).*", ErrorMessage ="O campo {0} deve conter entre 1 e 100 caracteres.")]
        [Column(TypeName = "varchar(100)")]
        public string TipoLogradouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Nome do logradouro")]
        [RegularExpression(@"^(?=.{1,100}$).*", ErrorMessage = "O campo {0} deve conter entre 1 e 100 caracteres.")]
        [Column(TypeName = "varchar(100)")]
        public string NomeLogradouro { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Column(TypeName = "int")]
        [RegularExpression(@"^(\d{1,6})$", ErrorMessage = "O campo {0} deve conter entre 1 e 6 dígitos.")]
        public int Numero { get; set; }

        [Display(Name = "Complemento")]
        [RegularExpression(@"^(?=.{1,100}$).*", ErrorMessage = "O campo {0} deve conter entre 1 e 100 caracteres.")]
        [Column(TypeName = "varchar(100)")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "CEP")]
        [Column(TypeName = "varchar(8)")]
        [RegularExpression(@"^(\d{8})$", ErrorMessage = "O campo {0} deve conter 8 dígitos.")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Bairro")]
        [RegularExpression(@"^(?=.{1,100}$).*", ErrorMessage = "O campo {0} deve conter entre 1 e 100 caracteres.")]
        [Column(TypeName = "varchar(100)")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Cidade")]
        [RegularExpression(@"^(?=.{1,100}$).*", ErrorMessage = "O campo {0} deve conter entre 1 e 100 caracteres.")]
        [Column(TypeName = "varchar(100)")]
        public string Cidade { get; set; }
        //Coloquei validação, mas sugiro que mudem para UF, assim podemos usar somente as siglas e padronizar no banco
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Estado")]
        [RegularExpression(@"^(?=.{1,100}$).*", ErrorMessage = "O campo {0} deve conter entre 1 e 100 caracteres.")]
        [Column(TypeName = "varchar(100)")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "País")]
        [RegularExpression(@"^(?=.{1,100}$).*", ErrorMessage = "O campo {0} deve conter entre 1 e 100 caracteres.")]
        [Column(TypeName = "varchar(100)")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Tipo de endereço")]
        [RegularExpression(@"^(?=.{1,100}$).*", ErrorMessage = "O campo {0} deve conter entre 1 e 100 caracteres.")]
        [Column(TypeName = "varchar(100)")]
        public string TipoEndereco { get; set; }
    }
}
