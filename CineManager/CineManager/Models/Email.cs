using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Models
{
    public class Email
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        [RegularExpression(@"^(?=.{1,100}$).*", ErrorMessage = "O campo {0} deve conter entre 1 e 160 caracteres")]
        [Column(TypeName = "varchar(160)")]
        public string EnderecoEmail { get; set; }
    }
}
