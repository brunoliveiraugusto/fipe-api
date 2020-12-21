using Fipe.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fipe.Data.Mappings
{
    class VeiculoMarcaMap : IEntityTypeConfiguration<VeiculoMarca>
    {
        public void Configure(EntityTypeBuilder<VeiculoMarca> builder)
        {
            builder.HasKey(k => k.IdVeiculoMarca);
            builder.Property(p => p.AnoReferencia);
            builder.Property(p => p.Chave);
            builder.Property(p => p.FipeMarca);
            builder.Property(p => p.FipeMarcaApi);
            builder.Property(p => p.FipeNome);
            builder.Property(p => p.IdFipe);
            builder.Property(p => p.IdMarca);
            builder.Property(p => p.MesReferencia);
            builder.Property(p => p.Nome);
            builder.Ignore(p => p.Marca);
            builder.ToTable("VeiculoMarca");
        }
    }
}
