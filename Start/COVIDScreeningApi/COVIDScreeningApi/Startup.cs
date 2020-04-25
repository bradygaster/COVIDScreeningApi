using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COVIDScreeningApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace COVIDScreeningApi
{
    public class Startup
    {
        const string SWAGGER_DOC_NAME = "v1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(config =>
            {
                config.DocumentFilter<DefaultWebHostNameDocumentFilter>(Configuration);
                config.SwaggerDoc(SWAGGER_DOC_NAME, 
                    new OpenApiInfo
                    {
                        Title = "COVIDScreeningApi",
                        Version = SWAGGER_DOC_NAME
                    });
            });

            services.AddDbContext<DataContext>(optionsBuilder =>
            {
                optionsBuilder.UseCosmos(
                    Configuration.GetConnectionString("CosmosDbConnectionString"),
                    "COVIDScreeningDb");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwaggerUI(config => 
                {
                    config.SwaggerEndpoint($"/swagger/{SWAGGER_DOC_NAME}/swagger.json", SWAGGER_DOC_NAME);
                });
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

