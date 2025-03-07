
using MyYTLoader.Domain;

namespace MyYTLoader.Web.HostedServices
{
    public class MyHostedService : IHostedService
    {
        private readonly ILogsProvider _logsProvider;
        private Task? _doWorkTask;

        public MyHostedService(ILogsProvider logsProvider)
        {
            _logsProvider = logsProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _doWorkTask = Task.Run(() => DoWork(cancellationToken));
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Task.WaitAll(_doWorkTask);
            Console.WriteLine("Мы остановили MyHostedService");
            return Task.CompletedTask;
        }

        private async Task DoWork(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                _logsProvider.AddLog(DateTime.UtcNow.ToString());
                await Task.Delay(1000);
            }
        }
    }
}
