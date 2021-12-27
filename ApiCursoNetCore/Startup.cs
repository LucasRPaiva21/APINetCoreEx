using ApiCursoNetCore.Data.Context;
using APICursoNetCore.CrossCutting.DependencyInjection;
using APICursoNetCore.Domain.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;

namespace ApiCursoNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {           
            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services);

            var signingConfiguration = new SigningConfigurations();
            services.AddSingleton(signingConfiguration);

            var tokenConfigurations = new TokenConfiguration();
            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                Configuration.GetSection("TokenConfigurations"))
                .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Curso de API com AspNetCore 3.1 - Na Prática",
                    Description = "Arquitetura DDD",
                    TermsOfService = new Uri("http://www.mfrinfo.com.br"),
                    Contact = new OpenApiContact
                    {
                        Name = "Lucas Ramalho Paiva",
                        Email = "lucas.ramalhopaiva@hotmail.com",
                        Url = new Uri("http://www.mrfinfo.com.br")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Termo de Licença de Uso"
                    }
                }
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
           {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "Curso de API com AspNetCore 3.1");
               c.RoutePrefix = string.Empty;
           });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
