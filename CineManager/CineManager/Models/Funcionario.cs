﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineManager.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "Nome Completo")]
        [MaxLength(20, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve ter no minimo {1} caracteres")]
        [Column(TypeName = "varchar(20)")] 
        public string NomeCompleto{ get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Column(TypeName = "varchar(30)")]
        [MaxLength(30, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve ter no minimo {1} caracter")]
        public string Setor { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "CPF")]
        [Column(TypeName = "bigint")]
        [RegularExpression("^[0-9]*$")]
        [MaxLength(11, ErrorMessage = "O campo {0} 11 caracteres")]
        [MinLength(11, ErrorMessage = "O campo {0} 11 caracteres")]
        public long Cpf { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "RG")]
        [Column(TypeName = "bigint")]
        [RegularExpression("^[0-9]*$")]
        [MaxLength(11, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(7, ErrorMessage = "O campo {0} deve ter no minimo {1} caracter")]
        public long Rg { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Display(Name = "Salário")]
        [Column(TypeName = "decimal(12,3)")]
        [RegularExpression("^[0-9]*$")]
        [MaxLength(18, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve ter no minimo {1} caracter")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Column(TypeName = "varchar(30)")]
        [MaxLength(30, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve ter no minimo {1} caracter")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório")]
        [Column(TypeName = "varchar(15)")]
        [MaxLength(15, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(1, ErrorMessage = "O campo {0} deve ter no minimo {1} caracter")]
        public string Turno { get; set; }

        [Display(Name ="Endereço")]
        public List<Telefone> Telefones { get; set; }
        public List<Endereco> Enderecos { get; set; }
        public Telefone Telefone { get; set; }
        public Endereco Endereco { get; set; }
    }
}
