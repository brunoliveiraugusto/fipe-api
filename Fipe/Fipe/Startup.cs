using AutoMapper;
using Fipe.Application.AutoMapper;
using Fipe.Application.Interfaces;
using Fipe.Application.Services;
using Fipe.Data.Context;
using Fipe.Data.Interfaces;
using Fipe.Data.Repository;
using Fipe.Generics.Factory;
using Fipe.Generics.Factory.Interface;
using Fipe.Integration;
using Fipe.Integration.Request;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Reflection;

namespace Fipe
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region DI
            //AppService
            services.AddScoped<IMarcaAppService, MarcaAppService>();
            services.AddScoped<IFipeAppService, FipeAppService>();
            services.AddScoped<IVeiculoMarcaAppService, VeiculoMarcaAppService>();

            //Request
            services.AddScoped<IMarcaRequest, MarcaRequest>();
            services.AddTransient<HttpClient>();

            //Repository
            services.AddScoped<IParametroRepository, ParametroRepository>();
            services.AddScoped<ITipoVeiculoRepository, TipoVeiculoRepository>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<ILogFipeRepository, LogFipeRepository>();

            //Generics
            services.AddScoped<IFactory, Factory>();

            //DataBase
            services.AddDbContext<FipeContext>(x => x.UseSqlServer(Configuration.GetConnectionString("Fipe")), ServiceLifetime.Transient);
            #endregion

            #region Mapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DataRequestToEntitie());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            #region Swagger
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Fipe API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);
            });
            #endregion
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
                endpoints.MapControllers();
            });

            #region Swagger
            app.UseSwagger();

            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Fipe API");
            });
            #endregion
        }
    }
}
