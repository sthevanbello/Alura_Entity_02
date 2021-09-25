using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraFilmesContexto())
            {
                contexto.LogSQLToConsole();
                //StoredProcedure(contexto);

                var sql = "INSERT INTO language (name) VALUES ('Idioma 1'), ('Idioma 2'), ('Idioma 3')";
                var registros = contexto.Database.ExecuteSqlCommand(sql);
                Console.WriteLine($"Total de registros afetados: {registros}");

                Console.WriteLine("=============================================================");
                
                var deleteSql = @"DELETE FROM language WHERE name LIKE 'Idioma%' ";
                var registrosDelete = contexto.Database.ExecuteSqlCommand(deleteSql);
                Console.WriteLine($"Total de registros afetados: {registrosDelete}");
            }
            Console.ReadKey();
        }

        private static void StoredProcedure(AluraFilmesContexto contexto)
        {
            var categoria = "Action"; // 36
            var paramCategoria = new SqlParameter("category_name", categoria);
            var paramTotal = new SqlParameter
            {
                ParameterName = "@total_actors",
                Size = 4,
                Direction = ParameterDirection.Output
            };

            var sql = @"total_actors_from_given_category @category_name, @total_actors OUT";

            // Executar a stored procedure
            contexto.Database.ExecuteSqlCommand(sql, paramCategoria, paramTotal);

            Console.WriteLine($"O total de atores na categoria {categoria} é de {paramTotal.Value}");
        }

        private static void GetAtores(IList<FilmeAtor> atores)
        {
            foreach (var ator in atores)
            {
                Console.WriteLine(ator.Ator);
            }
        }

        private static void GetFilmes(List<Filme> filmes)
        {
            foreach (var filme in filmes)
            {
                Console.WriteLine(filme);
            }
        }

        private static void GetFilmeAtor(AluraFilmesContexto contexto, List<FilmeAtor> elenco)
        {
            foreach (var atorElenco in elenco)
            {
                var entidade = contexto.Entry(atorElenco);
                var filmId = entidade.Property("film_id").CurrentValue;
                var atorId = entidade.Property("actor_id").CurrentValue;
                var lastUpdate = entidade.Property("last_update").CurrentValue;

                Console.WriteLine($"Filme: {filmId} Ator: {atorId} Last Update: {lastUpdate}");
            }
        }

    }
}