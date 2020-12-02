using Fipe.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Fipe.Data.Context
{
    public class FipeContext : DbContext
    {
        public FipeContext(DbContextOptions options) : base(options) { }

        public DbSet<Parametro> Parametros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("Fipe"));
        }
    }
}
