using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CineManager.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public string NomeDaEmpresa { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public string NomeResponsavel { get; set; }
    }
}