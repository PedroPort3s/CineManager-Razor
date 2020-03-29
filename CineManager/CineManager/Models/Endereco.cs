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

        [Display(Name = "Tipo De Logradouro")]
        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Column(TypeName = "varchar(100)")]
        public string TipoLogradouro { get; set; }
        
        
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Column(TypeName = "varchar(100)")]
        public string NomeLogradoudro { get; set; }


        [Display(Name = "Numero")]
        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Column(TypeName = "int")]
        public int Number { get; set; }

        
        [Column(TypeName = "varchar(100)")]
        public string Complemento { get; set; }


        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "CEP")]
        [Column(TypeName = "varchar(10)")]
        [RegularExpression("^[0-9]*$")]
        [Range(8, 8, ErrorMessage = "O {0} deve ser de 8 caracteres")]
        public string Cep { get; set; }
        

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Column(TypeName = "varchar(100)")]
        public string Bairro { get; set; }
       

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Column(TypeName = "varchar(100)")]
        public string Cidade { get; set; }
       
        
        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Column(TypeName = "varchar(100)")]
        public string Estado { get; set; }
        
        
        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Column(TypeName = "varchar(100)")]
        public string Pais { get; set; }


        [Display(Name = "Tipo De Endereço")]
        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Column(TypeName = "varchar(100)")]
        public string TipoEndereco { get; set; }


    }
}
