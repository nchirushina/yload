using FluentAssertions;
using Moq;
using MyYTLoader.DAL.Entities;
using MyYTLoader.DAL.Repositories;
using MyYTLoader.Domain.Services;

namespace MyYTLoader.Domain.Tests
{
    public class RequestServiceTests
    {
        [Fact]
        public void Should_Not_Create_Duplicate_Urls_In_Db()
        {
            // Arrange
            var videoRepositoryMock = new Mock<IVideoRepository>(
                    MockBehavior.Strict);

            var uri = "mockUri";

            videoRepositoryMock
                .Setup(vrm => vrm.Any(It.Is<string>(s => s == uri)))
                .Returns(true);

            var videoId = Guid.NewGuid();
            var videoEntityMock = new VideoEntity()
            {
                Url = uri,
                State = VideoState.New,
                Created = DateTime.UtcNow,
                Id = videoId,
            };

            videoRepositoryMock
                .Setup(vrm => vrm.Add(It.Is<VideoEntity>(
                    ve => ve.Url == uri)))
                .Returns(videoId);

            var systemUnderTest = new RequestService(videoRepositoryMock.Object);

            // Act
            var result = systemUnderTest.AddVideo(uri);

            // Assert
            result.Should().Be(Guid.Empty);

        }

        [Fact]
        public void Should_Create_New_VideoEntity_If_Url_Is_Nor_Exists()
        {
            // Arrange
            var videoRepositoryMock = new Mock<IVideoRepository>();// (MockBehavior.Strict);
            var uri = "MockUri";
            var resultGuid = Guid.NewGuid();
            var videoEntity = new VideoEntity()
            {
                Created = DateTime.UtcNow,
                State = VideoState.New,
                Url = uri,
            };

            videoRepositoryMock
                            .Setup(vrm => vrm.Add(It.Is<VideoEntity>(ve => ve.Url == videoEntity.Url)))
                            .Returns(resultGuid);
            
            var systemUnderTest = new RequestService (videoRepositoryMock.Object);

            // Act
            var result = systemUnderTest.AddVideo(uri);

            // Assert
            result.Should().Be(resultGuid);
        }
    }
}