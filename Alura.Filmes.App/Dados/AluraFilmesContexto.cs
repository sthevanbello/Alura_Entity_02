using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Filmes.App.Dados
{
    public class AluraFilmesContexto : DbContext
    {
        public DbSet<Ator> Atores { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<FilmeAtor> Elenco { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<FilmeCategoria> FilmeCategoria { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AluraFilmes;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AluraFilmesTST;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ator
            modelBuilder.ApplyConfiguration(new AtorConfiguration());
            // Filmes
            modelBuilder.ApplyConfiguration(new FilmeConfiguration());
            // Filme AtorConfiguration
            modelBuilder.ApplyConfiguration(new FilmeAtorConfiguration());
            // Categoria Configuration
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
            // Filme Categoria Configuration
            modelBuilder.ApplyConfiguration(new FilmeCategoriaConfiguration());
            // Idioma Configration
            modelBuilder.ApplyConfiguration(new IdiomaConfiguration());

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());

            modelBuilder.ApplyConfiguration(new FuncionarioConfiguration());
        }


    }
}
