

using CaseTecnicoIt.Domain.Interfaces;
using CaseTecnicoIt.Domain.Models;
using CaseTecnicoIt.Extensions.CaseTecnicoIt.Extensions;
using CaseTecnicoIt.Infra.Data.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;
using static CaseTecnicoIt.Extensions.FailFastRequestBehavior;

namespace CaseTecnicoIt
{
    public class Startup
    {

        private const string CULTURE_INFO = "pt-BR";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


          //  services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase(databaseName: "FakeBD"));
            // SWAGGER
            services.AddSwagger();
            AddMediatr(services);
            // Injecao de dependecia
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IFilmesRepository, FilmesRepository>();
            services.AddScoped<ILocacaoRepository, LocacaoRepository>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var supportedCultures = new[] { new CultureInfo(CULTURE_INFO) };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: CULTURE_INFO, uiCulture: CULTURE_INFO),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "v1"));

           // var context = app.ApplicationServices.GetService<ApiContext>();
          //  DadosFake(context);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private static void AddMediatr(IServiceCollection services)
        {
            const string applicationAssemblyName = "CaseTecnicoIt";
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationRequestBehavior<,>));

            services.AddMediatR(assembly);
        }



        private static void DadosFake(ApiContext context)
        {
            var testecliente = new Cliente
            {
                IdCliente = Guid.NewGuid(),
                nomeCliente = "victor"
            };

            context.clientes.Add(testecliente);

            context.SaveChanges();
        }

    }
}
