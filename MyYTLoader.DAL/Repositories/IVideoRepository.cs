using MyYTLoader.DAL.Entities;

namespace MyYTLoader.DAL.Repositories
{
    public interface IVideoRepository
    {
        List<VideoEntity> GetAll();
        VideoEntity? GetById(Guid id);

        bool SetState(Guid guid, VideoState videoState);
        List<VideoEntity> GetAllNew();
        Guid GetByUrl(string uri);
        Guid Add(VideoEntity videoEntity);
        bool Any(string url);
    }
}