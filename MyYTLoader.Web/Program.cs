using Microsoft.Extensions.Configuration;
using MyYTLoader.DAL;
using MyYTLoader.Domain;
using MyYTLoader.Domain.Configs;
using MyYTLoader.Domain.Services;
using MyYTLoader.Web.HostedServices;

namespace MyYTLoader.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<ILogsProvider, LogsProvider>();
            builder.Services.AddScoped<IDownloadService, DownloadService>();
            builder.Services.AddScoped<IYtDlpWrapper, YtDlpWrapper>();
            builder.Services.AddScoped<IRequestService, RequestService>();
            builder.Services.AddHostedService<RequestDownloaderWorker>();
            builder.Services.Configure<YtDlpWrapperConfig>(builder.Configuration.GetSection(nameof(YtDlpWrapperConfig)));
            builder.Services.RegisterDALservices(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
