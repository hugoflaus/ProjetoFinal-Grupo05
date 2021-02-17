using System;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using System.IO;
using api.Dominio.Entidade.Usuario;
using api.Dominio.Entidade.Veiculo;
using api.Dominio.Entidade.Agendamento;

namespace api.Infra.Database
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options): base(options){}

        public EntityContext(){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:localizabd.database.windows.net,1433;Initial Catalog=localiza;Persist Security Info=False;User ID=hugo;Password=localiza85@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veiculo>()
                .HasOne(v => v.Marca)
                .WithMany(m => m.Veiculos)
                .HasForeignKey(v => v.IdMarca);
            modelBuilder.Entity<Veiculo>()
                .HasOne(v => v.Categoria)
                .WithMany(c => c.Veiculos)
                .HasForeignKey(v => v.IdCategoria);
            modelBuilder.Entity<Veiculo>()
                .HasOne(v => v.Modelo)
                .WithMany(m => m.Veiculos)
                .HasForeignKey(v => v.IdModelo);

            modelBuilder.Entity<Agendamento>()
                .HasOne(a => a.Veiculo)
                .WithMany( v => v.Agendamentos)
                .HasForeignKey( a => a.IdVeiculo);
            modelBuilder.Entity<Agendamento>()
                .HasOne(a  => a.Pessoa)
                .WithMany(p => p.Agendamentos)
                .HasForeignKey(a => a.IdPessoa);

            modelBuilder.Entity<Checklist>()
                .HasOne(c => c.Agendamento)
                .WithOne(a => a.Checklist)
                .HasForeignKey<Agendamento>(c => c.IdChecklist);    
        }
        public DbSet<Pessoa> Usuario { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Modelo> Modelo { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<Checklist> Checklist { get; set; }
    }
}
