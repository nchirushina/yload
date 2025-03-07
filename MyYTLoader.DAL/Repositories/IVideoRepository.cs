using MyYTLoader.DAL.Entities;

namespace MyYTLoader.DAL.Repositories
{
    public interface IVideoRepository
    {
        IQueryable<VideoEntity> GetAll();
        VideoEntity? GetById(Guid id);
    }
}