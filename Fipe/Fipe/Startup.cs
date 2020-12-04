using Fipe.Application.Interfaces;
using Fipe.Application.Services;
using Fipe.Data.Context;
using Fipe.Data.Interfaces;
using Fipe.Data.Repository;
using Fipe.Integration;
using Fipe.Integration.Request;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fipe
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            //AppService
            services.AddScoped<IMarcaAppService, MarcaAppService>();
            services.AddScoped<IFipeAppService, FipeAppService>();

            //Request
            services.AddScoped<IMarcaRequest, MarcaRequest>();

            //Repository
            services.AddScoped<IParametroRepository, ParametroRepository>();
            services.AddScoped<ITipoVeiculoRepository, TipoVeiculoRepository>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();

            //DataBase
            services.AddDbContext<FipeContext>(x => x.UseSqlServer(Configuration.GetConnectionString("Fipe")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
