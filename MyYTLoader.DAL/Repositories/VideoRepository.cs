using MyYTLoader.DAL.Entities;

namespace MyYTLoader.DAL.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly LoaderContext _db;

        public VideoRepository(LoaderContext db)
        {
            _db = db;
        }

        public IQueryable<VideoEntity> GetAll()
        {
            return _db.Videos;
        }

        public VideoEntity? GetById(Guid id)
        {
            return _db.Videos.SingleOrDefault(v => v.Id == id);
        }
    }
}
