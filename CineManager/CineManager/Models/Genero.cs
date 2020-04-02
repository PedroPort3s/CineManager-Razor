﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Models
{
    public class Genero
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "Nome do gênero")]
        [RegularExpression(@"^[A-Z0-9]+[a-zA-Z0-9""'\s-]*$")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve ter no minimo {1} caracteres")]
        [Column(TypeName = "varchar(50)")]
        public string Nome{ get; set; }
    }
}