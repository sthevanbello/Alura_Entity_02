using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Filmes.App.Dados
{
    public class AluraFilmesContexto : DbContext
    {
        public DbSet<Ator> Atores { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)mssqllocaldb;Database=AluraFilmes;Trusted_connection=true;");
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AluraFilmes;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AluraFilmesTST;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ator>().ToTable("actor");
            modelBuilder.Entity<Ator>().Property(a => a.Id).HasColumnType("int").HasColumnName("actor_id");
            modelBuilder.Entity<Ator>().Property(a => a.PrimeiroNome).HasColumnName("first_name").HasColumnType("varchar(45)").IsRequired();
            modelBuilder.Entity<Ator>().Property(a => a.UltimoNome).HasColumnName("last_name").HasColumnType("varchar(45)").IsRequired();

            // Criação de um valor padrão para a Shadow Property last_update (Só existe no banco e é gerada automaticamente)
            modelBuilder.Entity<Ator>().Property<DateTime>("last_update").HasColumnType("datetime").HasDefaultValueSql("getdate()").IsRequired();

            // Filmes

            modelBuilder.Entity<Filme>().ToTable("film");
            modelBuilder.Entity<Filme>().Property(f => f.Id).HasColumnName("film_id");
            modelBuilder.Entity<Filme>().Property(f => f.Titulo).HasColumnType("varchar(255)").HasColumnName("title").IsRequired();
            modelBuilder.Entity<Filme>().Property(f => f.Descricao).HasColumnType("text").HasColumnName("description");
            modelBuilder.Entity<Filme>().Property(f => f.AnoLancamento).HasColumnType("varchar(4)").HasColumnName("release_year");
            modelBuilder.Entity<Filme>().Property(f => f.Duracao).HasColumnName("length");

            // Criação de um valor padrão para a Shadow Property last_update (Só existe no banco e é gerada automaticamente)
            modelBuilder.Entity<Filme>().Property<DateTime>("last_update").HasColumnType("datetime").HasDefaultValueSql("getdate()").IsRequired();
        }


    }
}
