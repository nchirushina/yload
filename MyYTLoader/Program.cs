using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyYTLoader.DAL;

namespace MyYTLoader
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration(builder =>
                   builder.AddJsonFile("appsettings.json"))
               .ConfigureServices((context, services) =>
               {
                   services.AddHostedService<WorkHostedService>();
                   services.RegisterDALservices(context.Configuration);
               })
               .Build()
               .RunAsync();
        }
    }
}
