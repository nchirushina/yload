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

        public List<VideoEntity> GetAll()
        {
            return _db.Videos.ToList();
        }

        public VideoEntity? GetById(Guid id)
        {
            return _db.Videos.SingleOrDefault(v => v.Id == id);
        }

        public List<VideoEntity> GetAllNew()
        {
            return _db.Videos.Where(v => v.State == VideoState.New).ToList();
        }

        public bool SetState(Guid guid, VideoState videoState)
        {
            var video = this.GetById(guid);
            if (video == null)
            {
                return false;
            }

            video.State = videoState;
            _db.Videos.Update(video);
            _db.SaveChanges();
            return true;
        }

        public Guid Add(VideoEntity videoEntity)
        {
            _db.Videos.Add(videoEntity);
            _db.SaveChanges();
            return videoEntity.Id;
        }

        public bool Any(string url)
        {
            return _db.Videos.Any(v => v.Url == url);
        }

        public Guid GetByUrl(string uri)
        {
            return _db.Videos.FirstOrDefault(v => v.Url == uri).Id;
        }
    }
}
