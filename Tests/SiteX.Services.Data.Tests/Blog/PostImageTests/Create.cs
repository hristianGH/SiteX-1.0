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

    public class Create
    {
        [Fact]
        public async Task CreatePostImageShouldGetCreated()
        {
            var listPosts = new List<PostImage>();

            var mockRepo = new Mock<IDeletableEntityRepository<PostImage>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(listPosts.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<PostImage>())).Callback((PostImage x) => listPosts.Add(x));

            var postImageService = new PostImageService(mockRepo.Object);
            var paths = new string[] { "path1", "path2" };

            await postImageService.CreatingPostImageAsync(paths, 1);

            Assert.NotEmpty(listPosts);
            Assert.Contains(listPosts, x => x.Path == "path1");
            Assert.Contains(listPosts, x => x.Path == "path2");
        }
    }
}
