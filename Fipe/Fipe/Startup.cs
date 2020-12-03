using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fipe.Application.Interfaces;
using Fipe.Application.Services;
using Fipe.Data.Context;
using Fipe.Data.Interfaces;
using Fipe.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fipe
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //AppService
            services.AddScoped<IMarcaAppService, MarcaAppService>();
            services.AddScoped<IFipeAppService, FipeAppService>();

            //Repository
            services.AddScoped<IParametroRepository, ParametroRepository>();

            //DataBase
            services.AddScoped<FipeContext>();
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
