
using MyYTLoader.Domain;
using System.Threading;

namespace MyYTLoader.Web.HostedServices
{
    public class MyHostedService : BackgroundService
    {
        private readonly ILogsProvider _logsProvider;
        private Task? _doWorkTask;

        public MyHostedService(ILogsProvider logsProvider)
        {
            _logsProvider = logsProvider;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logsProvider.AddLog(DateTime.UtcNow.ToString());
                await Task.Delay(1000);
            }
        }
    }
}
