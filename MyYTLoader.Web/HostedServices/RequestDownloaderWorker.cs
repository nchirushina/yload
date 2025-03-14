namespace MyYTLoader.Web.HostedServices;

using Microsoft.Extensions.Options;
using MyYTLoader.DAL.Entities;
using MyYTLoader.DAL.Repositories;
using MyYTLoader.Domain;
using MyYTLoader.Domain.Configs;

public class RequestDownloaderWorker : BackgroundService
{
    private readonly ILogsProvider _logsProvider;
    private readonly IServiceProvider _serviceProvider;

    public RequestDownloaderWorker(
        ILogsProvider logsProvider,
        IServiceProvider serviceProvider)
    {
        _logsProvider = logsProvider;
        _serviceProvider = serviceProvider;
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var videoRepository = scope.ServiceProvider.GetService<IVideoRepository>()
                        ?? throw new Exception($"Cannot instantiate {nameof(IVideoRepository)}");

                    var ytDlpWrapper = scope.ServiceProvider.GetService<IYtDlpWrapper>()
                        ?? throw new Exception($"Cannot instantiate {nameof(IYtDlpWrapper)}");

                    var config = scope.ServiceProvider.GetService<IOptions<YtDlpWrapperConfig>>()
                        ?? throw new Exception($"Cannot instantiate {nameof(YtDlpWrapperConfig)}");

                    _logsProvider.AddLog(DateTime.UtcNow.ToString());
                    var newVideos = videoRepository.GetAllNew();
                    if (newVideos.Count == 0)
                    { 
                        await Task.Delay(1000);
                        continue;
                    }

                    foreach (var video in newVideos)
                    {
                        DownloadVideo(video, videoRepository, ytDlpWrapper, config.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                _logsProvider.AddLog(ex.Message);
            }
        }
    }

    private void DownloadVideo(
        VideoEntity video,
        IVideoRepository videoRepository,
        IYtDlpWrapper ytDlpWrapper,
        YtDlpWrapperConfig config)
    {
        try
        {
            videoRepository.SetState(video.Id, VideoState.Processing);
            if (!Uri.IsWellFormedUriString(video.Url, UriKind.Absolute))
            {
                throw new UriFormatException();
            }

            ytDlpWrapper.Run(config.YtdlpBinaryPath, video.Url);
            videoRepository.SetState(video.Id, VideoState.Done);
        }
        catch (Exception ex)
        {
            videoRepository.SetState(video.Id, VideoState.Error);
        }
    }
}
