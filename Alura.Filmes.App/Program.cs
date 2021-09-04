using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraFilmesContexto())
            {
                //contexto.LogSQLToConsole();

                //var atores = contexto.Atores.OrderByDescending(a => EF.Property<DateTime>(a, "last_update")).Take(10);

                //ListaAtores(atores, contexto);

                var filmes = contexto.Filmes.ToList();

                foreach (var filme in filmes)
                {
                    Console.WriteLine(filme);
                }
                
            }
            Console.ReadKey();
        }

        private static void ListaAtores(IQueryable<Ator> atores, AluraFilmesContexto contexto)
        {
            foreach (var ator in atores)
            {
                Console.WriteLine($"{ator} - {contexto.Entry(ator).Property("last_update").CurrentValue}");
            }
        }



    }
}