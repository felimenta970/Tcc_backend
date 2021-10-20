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
        public DbSet<RelacaoUserStory> RelacaoUserStories { get; set; }
        public DbSet<CommitChecker> CommitChecker { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            optionsBuilder.UseSqlServer("Server=tcp:tcc-backend.database.windows.net,1433;Initial Catalog=tcc_backend2;Persist Security Info=False;User ID=felimenta;Password=Az11617!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Projeto>()
                .Property(p => p.InitialDate)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
