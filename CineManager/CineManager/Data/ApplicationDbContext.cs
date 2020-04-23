using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CineManager.Models;

namespace CineManager.Data {
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }
        public DbSet<Filme> Filme { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<TipoSala> TipoSala { get; set; }
        public DbSet<Sessao> Sessao { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<TipoFilme> TipoFilmes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<FilmeGenTipo> ListaFilmeGenTipo { get; set; }
    }
}
