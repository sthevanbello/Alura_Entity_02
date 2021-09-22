﻿using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Dados
{
    //public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    public class FuncionarioConfiguration : PessoaConfiguration<Funcionario>
    {
        public override void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            base.Configure(builder);

            builder.ToTable("staff");
            builder.Property(c => c.Id).HasColumnName("staff_id").HasColumnType("tinyint");
            builder.Property(c => c.Login).HasColumnName("username").HasColumnType("varchar(16)").IsRequired();
            builder.Property(c => c.Senha).HasColumnName("password").HasColumnType("varchar(40)");

            
        }
    }
}