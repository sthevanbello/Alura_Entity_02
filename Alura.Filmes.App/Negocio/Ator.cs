﻿using System.Collections.Generic;

namespace Alura.Filmes.App.Negocio
{

    public class Ator
    {
        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public IList<FilmeAtor> Filmografia { get; internal set; }

        public Ator()
        {
            Filmografia = new List<FilmeAtor>();
        }
        public override string ToString()
        {
            return $"({Id}): {PrimeiroNome} {UltimoNome}";
        }
    }
}
