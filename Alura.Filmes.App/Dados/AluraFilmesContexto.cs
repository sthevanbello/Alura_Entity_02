using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App.Dados
{
    public class AluraFilmesContexto : DbContext
    {
        public DbSet<Ator> Atores { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)mssqllocaldb;Database=AluraFilmes;Trusted_connection=true;");
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AluraFilmes;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ator>().ToTable("actor");
            modelBuilder.Entity<Ator>().Property(a => a.Id).HasColumnType("actor_id");
            modelBuilder.Entity<Ator>().Property(a => a.PrimeiroNome).HasColumnName("first_name").HasColumnType("varchar(45)").IsRequired();
            modelBuilder.Entity<Ator>().Property(a => a.UltimoNome).HasColumnName("last_name").HasColumnType("varchar(45)").IsRequired();

        }


    }
}
