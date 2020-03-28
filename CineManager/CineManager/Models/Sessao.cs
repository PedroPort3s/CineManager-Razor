using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Models
{
    public class Sessao
    {
        public int Id { get; set; }
        [Required]
        public int Duracao_Sessao { get; set; }
        [Required]
        public string Filme { get; set; }
        [Required]
        public int Sala { get; set; }


    }
}
