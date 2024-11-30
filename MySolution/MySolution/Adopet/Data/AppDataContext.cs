using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Adopet.Models;

namespace Adopet.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Abrigo> Abrigos { get; set; }
        public DbSet<Animal> Animais { get; set; }
        public DbSet<Adotante> Adotantes { get; set; }
        public DbSet<Adocao> Adocoes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=BancoAdopet.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração do relacionamento Adocao -> Animal
            modelBuilder.Entity<Adocao>()
                .HasOne(a => a.Animal)
                .WithMany()
                .HasForeignKey(a => a.AnimalId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração do relacionamento Adocao -> Adotante
            modelBuilder.Entity<Adocao>()
                .HasOne(a => a.Adotante)
                .WithMany(a => a.Adocoes)
                .HasForeignKey(a => a.AdotanteId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração do relacionamento Animal -> Abrigo
            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Abrigo)
                .WithMany(a => a.Animais)
                .HasForeignKey(a => a.AbrigoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
