using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Models {
    public class Telefone {
        public int Id { get; set; }
        
        [Column(TypeName = "varchar(10)")]
        public string Tipo { get; set; }

        [Display(Name = "DDD")]
        [Column(TypeName = "int")]
        public int DDD { get; set; }

        [Display(Name = "Número")]
        [Column(TypeName = "bigint")]
        public long Numero { get; set; }
        
        [Column(TypeName = "varchar(5)")]
        [DefaultValue("+55")]
        public string DDI { get; set; }
    }
}
