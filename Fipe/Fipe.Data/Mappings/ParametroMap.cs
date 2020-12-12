using Fipe.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fipe.Data.Mappings
{
    public class ParametroMap : IEntityTypeConfiguration<Parametro>
    {
        public void Configure(EntityTypeBuilder<Parametro> builder)
        {
            builder.HasKey(k => k.IdParametro);
            builder.Property(p => p.Ativo).HasColumnType("bit");
            builder.Property(p => p.DataCadastro).HasColumnType("datetime");
            builder.Property(p => p.NomeParametro).HasColumnType("varchar").HasMaxLength(200);
            builder.Property(p => p.Valor).HasColumnType("varchar").HasMaxLength(200);
            builder.ToTable("Parametro");
        }
    }
}
