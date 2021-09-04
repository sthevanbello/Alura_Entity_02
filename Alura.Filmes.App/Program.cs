using Alura.Filmes.App.Dados;
using System;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraFilmesContexto())
            {
                foreach (var ator in contexto.Atores)
                {
                    Console.WriteLine();
                }

            }
            Console.ReadKey();
        }
    }
}