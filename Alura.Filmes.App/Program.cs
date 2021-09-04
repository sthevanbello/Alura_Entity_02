using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using System;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraFilmesContexto())
            {
                contexto.LogSQLToConsole();

                Ator ator = new Ator();
                ator.PrimeiroNome = "Sthevan";
                ator.UltimoNome = "Bello";
                //contexto.Entry(ator).Property("last_update").CurrentValue = DateTime.Now;

                contexto.Atores.Add(ator);
                contexto.SaveChanges();


                ListAtores(contexto);
            }
            Console.ReadKey();
        }

        private static void ListAtores(AluraFilmesContexto contexto)
        {
            foreach (var ator in contexto.Atores)
            {
                Console.WriteLine(ator);
            }
        }
    }
}