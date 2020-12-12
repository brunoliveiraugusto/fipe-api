using Fipe.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fipe.Data.Mappings
{
    public class TipoVeiculoMap : IEntityTypeConfiguration<TipoVeiculo>
    {
        public void Configure(EntityTypeBuilder<TipoVeiculo> builder)
        {
            builder.HasKey(k => k.IdTipoVeiculo);
            builder.Property(p => p.DataCadastro);
            builder.Property(p => p.Descricao);
            builder.ToTable("TipoVeiculo");
        }
    }
}
