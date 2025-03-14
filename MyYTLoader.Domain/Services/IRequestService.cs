
using MyYTLoader.DAL.Entities;

namespace MyYTLoader.Domain.Services
{
    public interface IRequestService
    {
        Guid AddVideo(string uri);

        List<VideoEntity> GetAll();
    }
}