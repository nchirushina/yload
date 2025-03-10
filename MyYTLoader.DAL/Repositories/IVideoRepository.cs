using MyYTLoader.DAL.Entities;

namespace MyYTLoader.DAL.Repositories
{
    public interface IVideoRepository
    {
        IQueryable<VideoEntity> GetAll();
        VideoEntity? GetById(Guid id);

        public Guid GetByUrl(string uri);
        public Guid Add(VideoEntity videoEntity);
        public bool Any(string url);
    }
}