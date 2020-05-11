using CineManager.Models;
using System.ComponentModel.DataAnnotations;

namespace CineManager.ViewModels
{
    public class FuncionarioViewModel
    {
        public FuncionarioViewModel()
        {
            this.Funcionario = new Funcionario();
        }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Número")]
        [MaxLength(10, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        [MinLength(8, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        public string telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "DDD")]
        [MaxLength(4, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        public string ddd { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
