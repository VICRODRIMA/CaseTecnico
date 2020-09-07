namespace CaseTecnicoIt.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace CaseTecnicoIt.Extensions
    {
        internal static class SwaggerContainer
        {
            private const string repo = "https://github.com/VICRODRIMA/CaseTecnico";

            public static IServiceCollection AddSwagger(this IServiceCollection services)
            {
                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "API Case Tecnico",
                        Version = "v1",
                        Description = "api case tecnico itau para vag",
                        Contact = new OpenApiContact
                        {
                            Url = new Uri(repo),
                            Name = "Victor Matos",
                            Email = "vicrodrimap@gmail.com"
                        }
                    });
                });

                return services;
            }
        }
    }
}