using Microsoft.Extensions.Hosting;
using MyYTLoader.DAL.Entities;
using MyYTLoader.DAL.Repositories;

namespace MyYTLoader;

internal class WorkHostedService : BackgroundService
{
    private readonly IVideoRepository videoRepository;

    public WorkHostedService(IVideoRepository videoRepository)
    {
        this.videoRepository = videoRepository;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var video = new VideoEntity
        {
            Id = Guid.NewGuid(),
            Url = "zfs",
            Created = DateTime.UtcNow,
        };

        // добавляем их в бд
        //   videoRepository.Create(video);

        // получаем объекты из бд и выводим на консоль
        var videos = videoRepository.GetAll().ToList();
        Console.WriteLine("Users list:");
        foreach (var v in videos)
        {
            Console.WriteLine($"{v.Id}.{v.Url} - {v.Created}");
        }

        return Task.CompletedTask;
    }
}
