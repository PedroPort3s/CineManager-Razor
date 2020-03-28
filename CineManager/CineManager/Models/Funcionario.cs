using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public string NomeCompleto{ get; set; }
        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public string Endereco{ get; set; }
        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public string Setor { get; set; }
        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public long Cpf { get; set; }
        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public long Rg { get; set; }
        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public decimal Salario { get; set; }
        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public string Cargo { get; set; }
        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        public string Turno { get; set; }
    }
}
