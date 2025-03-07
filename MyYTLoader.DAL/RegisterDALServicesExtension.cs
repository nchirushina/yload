using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyYTLoader.DAL.Repositories;

namespace MyYTLoader.DAL
{
    public static class RegisterDALServicesExtension
    {
        public static IServiceCollection RegisterDALservices(
            this IServiceCollection services,
            IConfiguration config)
        {
            services.AddDbContext<LoaderContext>(options => options.UseNpgsql(
                config.GetConnectionString("PostgreSql")));

            services.AddScoped<IVideoRepository, VideoRepository>();

            return services;
        }
    }
}
