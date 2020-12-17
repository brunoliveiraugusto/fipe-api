using Fipe.Data.Entities;
using Fipe.Data.Interfaces;
using Fipe.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Fipe.Data.Context
{
    public class FipeContext : DbContext, IFipeContext
    {
        public FipeContext(DbContextOptions<FipeContext> options) : base(options) { }

        public DbSet<Parametro> Parametros { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<TipoVeiculo> TiposVeiculo { get; set; }
        public DbSet<LogFipe> LogsFipe { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("Fipe"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MarcaMap());
            modelBuilder.ApplyConfiguration(new ParametroMap());
            modelBuilder.ApplyConfiguration(new TipoVeiculoMap());
            modelBuilder.ApplyConfiguration(new LogFipeMap());
        }

        public async Task SaveChangesListAsync<T>(IEnumerable<T> list) where T : class
        {
            base.AddRange(list);
            await base.SaveChangesAsync();
        }

        public async Task SaveChangesAsync<T>(T obj) where T : class
        {
            base.Add(obj);
            await base.SaveChangesAsync();
        }
    }
}
