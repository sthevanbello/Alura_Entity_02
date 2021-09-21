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

                var livre = ClassificacaoIndicativa.Livre;
                var m10 = ClassificacaoIndicativa.MaioresQue10;
                var m13 = ClassificacaoIndicativa.MaioresQue13;
                var m14 = ClassificacaoIndicativa.MaioresQue14;
                var m18 = ClassificacaoIndicativa.MaioresQue18;
                //string textoLivre = "G";

                Console.WriteLine(livre.ParaString());
                Console.WriteLine(m10.ParaString());
                Console.WriteLine(m13.ParaString());
                Console.WriteLine(m14.ParaString());
                Console.WriteLine(m18.ParaString());

                Console.WriteLine("G".ParaValor());


                //var filme = new Filme();
                //filme.Titulo = "Senhor dos Anéis";
                //filme.Duracao = 120;
                //filme.AnoLancamento = "2000";
                //filme.Classificacao = ClassificacaoIndicativa.Livre;
                //filme.IdiomaFalado = contexto.Idiomas.First();
                //contexto.Entry(filme).Property("last_update").CurrentValue = DateTime.Now;

                //contexto.Filmes.Add(filme);
                //contexto.SaveChanges();

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