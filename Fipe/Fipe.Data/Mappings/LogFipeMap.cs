using Fipe.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fipe.Data.Mappings
{
    class LogFipeMap : IEntityTypeConfiguration<LogFipe>
    {
        public void Configure(EntityTypeBuilder<LogFipe> builder)
        {
            builder.HasKey(k => k.IdLogFipe);
            builder.Property(p => p.DataExcecao).HasColumnType("datetime");
            builder.Property(p => p.MensagemExcecao);
            builder.Property(p => p.Rastreamento);
            builder.Property(p => p.TipoExcecao);
            builder.ToTable("LogFipe");
        }
    }
}
