using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.Entities;

namespace Tcc_backend.DataBaseConfig {
    public class DatabaseContext : DbContext {

        public DbSet<Anexo> Anexo { get; set; }
        public DbSet<Commit> Commit { get; set; }
        public DbSet<Membro> Membro { get; set; }
        public DbSet<Mudanca> Mudanca { get; set; }
        public DbSet<ProjectManager> ProjectManager { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<Sprint> Sprint { get; set; }
        public DbSet<UserStory> UserStory { get; set; }
        public DbSet<UsuarioProjeto> UsuarioProjeto { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            optionsBuilder.UseSqlServer("Data Source=DESKTOP-S8M2H2O;Trusted_Connection=True;Integrated Security=True;Initial Catalog=tcc_backend");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Projeto>()
                .Property(p => p.InitialDate)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
