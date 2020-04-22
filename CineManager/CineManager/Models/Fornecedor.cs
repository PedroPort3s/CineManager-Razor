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

        public Fornecedor() {
            ListaTelefone = new List<Telefone>();
            ListaEndereco = new List<Endereco>();
            ListaEmail = new List<Email>();
        }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Nome da empresa")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        [Column(TypeName = "varchar(100)")]
        public string NomeDaEmpresa { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Nome do responsável")]
        [MaxLength(300, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        [Column(TypeName = "varchar(300)")]
        public string NomeResponsavel { get; set; }

        public List<Endereco> ListaEndereco { get; set; }
        public List<Telefone> ListaTelefone { get; set; }
        public List<Email> ListaEmail { get; set; }

        [NotMapped] public Endereco Endereco { get; set; }
        [NotMapped] public int EnderecoId { get; set; }
        [NotMapped] public Telefone Telefone { get; set; }
        [NotMapped] public int TelefoneId { get; set; }
        [NotMapped] public Email Email { get; set; }
        [NotMapped] public int EmailId { get; set; }
    }
}