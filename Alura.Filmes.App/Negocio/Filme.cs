namespace Alura.Filmes.App.Negocio
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public short Duracao { get; set; }
        public string AnoLancamento { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Titulo}\n{Descricao}\nDuração: {Duracao} - Ano: {AnoLancamento}";
        }
    }
}
