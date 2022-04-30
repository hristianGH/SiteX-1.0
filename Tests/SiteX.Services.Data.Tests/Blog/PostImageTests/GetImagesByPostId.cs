namespace SiteX.Services.Data.Tests.Blog.PostImageTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Moq;
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Blog;
    using SiteX.Services.Data.BlogService;
    using Xunit;

    public class GetImagesByPostId
    {
        [Fact]
        public async Task GetImageByPostIdShouldReturnValues()
        {
            var listPosts = new List<PostImage>();

            var mockRepo = new Mock<IDeletableEntityRepository<PostImage>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(listPosts.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<PostImage>())).Callback((PostImage x) => listPosts.Add(x));

            var postImageService = new PostImageService(mockRepo.Object);
            var paths = new string[] { "path1", "path2" };

            await postImageService.CreatingPostImageAsync(paths, 1);

            var images = postImageService.GetImagesByPostId(1);

            Assert.True(images.Count() == 2);
            Assert.Contains(images, x => x.Path == "path1");
            Assert.Contains(images, x => x.Path == "path2");
        }
    }
}
