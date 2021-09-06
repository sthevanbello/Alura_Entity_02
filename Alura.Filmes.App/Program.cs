using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                //var filmes = contexto.Filmes.ToList();


                //var elenco = contexto.Elenco.ToList();
                //GetFilmeAtor(contexto, elenco);
                //GetFilmes(filmes);


                var filme = contexto.Filmes.Include(f => f.Atores).ThenInclude(fa => fa.Ator).First();
                var atores = filme.Atores;

                Console.WriteLine(filme);
                Console.WriteLine("Elenco:");
                GetAtores(atores);

            }
            Console.ReadKey();
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