using System.Collections.Generic;

namespace Alura.Filmes.App.Negocio
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public short Duracao { get; set; }
        public string AnoLancamento { get; set; }
        public IList<FilmeAtor> Atores { get; set; }
        public IList<FilmeCategoria> Categoria { get; set; }


        public Filme()
        {
            Atores = new List<FilmeAtor>();
            Categoria = new List<FilmeCategoria>();
        }

        public override string ToString()
        {
            return $"{Id} - {Titulo}\n{Descricao}\nDuração: {Duracao} - Ano: {AnoLancamento}";
        }
    }
}
