using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Models {
    public class GeneroFilme {
        public int Id { get; set; }
        public Filme Filme { get; set; }
        public int FilmeId { get; set; }
        public Genero Genero { get; set; }
        public int GeneroId { get; set; }
        public TipoFilme TipoFilme { get; set; }
        public int TipoFilmeId { get; set; }
    }
}
