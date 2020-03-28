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
        public DbSet<CineManager.Models.Filme> Filme { get; set; }
        public DbSet<CineManager.Models.Funcionario> Funcionario { get; set; }
        public DbSet<CineManager.Models.Sala> Sala { get; set; }
        public DbSet<CineManager.Models.Sessao> Sessao { get; set; }
    }
}
