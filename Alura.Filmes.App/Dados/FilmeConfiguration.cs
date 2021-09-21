using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Dados
{
    public class FilmeConfiguration : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("film");
            builder.Property(f => f.Id).HasColumnName("film_id");
            builder.Property(f => f.Titulo).HasColumnType("varchar(255)").HasColumnName("title").IsRequired();
            builder.Property(f => f.Descricao).HasColumnType("text").HasColumnName("description");
            builder.Property(f => f.AnoLancamento).HasColumnType("varchar(4)").HasColumnName("release_year");
            builder.Property(f => f.Duracao).HasColumnName("length");

            // Criação de um valor padrão para a Shadow Property last_update (Só existe no banco e é gerada automaticamente)
            builder.Property<DateTime>("last_update").HasColumnType("datetime").HasDefaultValueSql("getdate()").IsRequired();

            builder.Property<byte>("language_id").IsRequired();
            // A tabela de filme possui o campo original_language_id como byte e pode conter valor nulo 'byte?'
            builder.Property<byte?>("original_language_id");

            builder.HasOne(f => f.IdiomaFalado).WithMany(f => f.FilmesFalados).HasForeignKey("language_id").IsRequired();
            builder.HasOne(f => f.IdiomaOriginal).WithMany(i => i.FilmesOriginais).HasForeignKey("original_language_id");

            builder.Property(f => f.TextoClassificacao).HasColumnType("varchar(10)").HasColumnName("rating");

            builder.Ignore(f => f.Classificacao);

        }
    }
}