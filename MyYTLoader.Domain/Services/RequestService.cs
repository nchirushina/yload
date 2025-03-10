using MyYTLoader.DAL.Entities;
using MyYTLoader.DAL.Repositories;

namespace MyYTLoader.Domain.Services
{
    public class RequestService
    {
        private readonly IVideoRepository _videoRepository;

        public RequestService(IVideoRepository videoRepository)
        {
            this._videoRepository = videoRepository;
        }

        public Guid AddVideo(string uri)
        {
            if (_videoRepository.Any(uri))
            {
                return _videoRepository.GetByUrl(uri);
            }

            var videoEntity = new VideoEntity()
            {
                Url = uri,
                Created = DateTime.UtcNow,
                State = VideoState.New,
            };

            var id = _videoRepository.Add(videoEntity);
            return id;
        }
    }
}
