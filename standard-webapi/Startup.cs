using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using standard_webapi.Business;
using standard_webapi.Business.Implementations;
using standard_webapi.Data.Mappings;
using standard_webapi.Data.Validation;
using standard_webapi.Models.DataContext;

namespace standard_webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Controllers and Validations
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddFluentValidation(x =>
                {
                    x.RegisterValidatorsFromAssemblyContaining<ClientDTOValidation>();
                    x.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
                });
            
            //Database Connection
            var connection = Configuration["MySQLConnection:MySQLConnectionString"];
            services.AddDbContext<Context>(options => options.UseMySql(connection));
            
            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Standard WebApi",
                        Version = "v1",
                        Description = "Just a ASP.NET Web Api using Entity Framework, AutoMapper and Swagger.",
                    });
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            
            //Dependency Injection
            services.AddScoped<IClientBusiness, ClientImplementation>();
            
            //AutoMapper
            services.AddAutoMapper(typeof(AutoMapperConfiguration));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "standard_webapi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}