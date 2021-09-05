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

                var filmes = contexto.Filmes.ToList();
                var elenco = contexto.Elenco.ToList();

                foreach (var atorElenco in elenco)
                {
                    var entidade = contexto.Entry(atorElenco);
                    var filmId = entidade.Property("film_id").CurrentValue;
                    var atorId = entidade.Property("actor_id").CurrentValue;
                    var lastUpdate = entidade.Property("last_update").CurrentValue; 
                     
                    Console.WriteLine($"{filmId} {atorId} {entidade} {lastUpdate}");
                }
                
            }
            Console.ReadKey();
        }

       
    }
}