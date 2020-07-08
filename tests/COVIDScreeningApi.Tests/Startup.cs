using System.Configuration;
using System.Reflection;
using COVIDScreeningApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;
using Microsoft.Extensions.Configuration;
using COVIDScreeningApi;

[assembly: TestFramework("COVIDScreeningApi.Tests.Startup", "COVIDScreeningApi.Tests")]

namespace COVIDScreeningApi.Tests
{
    public class Startup : DependencyInjectionTestFramework
    {
        IConfiguration Configuration = 
            new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        public Startup(IMessageSink messageSink) : base(messageSink) { }

        protected void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddDbContext<DataContext>(optionsBuilder =>
            {
                optionsBuilder.UseCosmos(
                    Configuration.GetConnectionString("CosmosDbConnectionString"),
                    "COVIDScreeningDb");
            });
        }

        protected override IHostBuilder CreateHostBuilder(AssemblyName assemblyName) =>
            base.CreateHostBuilder(assemblyName)
                .ConfigureServices(ConfigureServices);
    }
}