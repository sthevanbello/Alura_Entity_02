using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App.Negocio
{
    // Configurar a classe FilmeAtor para fazer o relacionamento da classe Filme com a classe Ator
    public class FilmeAtorConfiguration : IEntityTypeConfiguration<FilmeAtor>
    {
        public void Configure(EntityTypeBuilder<FilmeAtor> builder)
        {
            builder.ToTable("film_actor");
            builder.Property<int>("film_id");
            builder.Property<int>("actor_id");
            builder.Property<DateTime>("last_update").HasColumnType("datetime").HasDefaultValueSql("getdate()").IsRequired();
            builder.HasKey("film_id", "actor_id");
            builder.HasOne(fa => fa.Filme).WithMany(f => f.Atores).HasForeignKey("film_id");
            builder.HasOne(fa => fa.Ator).WithMany(f => f.Filmografia).HasForeignKey("actor_id");
        }
    }
}
