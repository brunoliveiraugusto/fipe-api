using Fipe.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fipe.Data.Mappings
{
    public class MarcaMap : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.HasKey(k => k.IdMarca);
            builder.Property(p => p.IdMarcaFipe);
            builder.Property(p => p.MesReferencia);
            builder.Property(p => p.Nome);
            builder.Property(p => p.NomeFipe);
            builder.Property(p => p.OrderFipe);
            builder.Property(p => p.Chave);
            builder.Property(p => p.AnoReferencia);
            builder.HasOne(p => p.TipoVeiculo)
                .WithMany(x => x.Marcas)
                .HasForeignKey(p => p.IdTipoVeiculo);

            builder.ToTable("Marca");

        }
    }
}
