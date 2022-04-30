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

    public class HardDelete
    {
        [Fact]
        public async Task HardDeleteShouldRemoveItemsFromRepository()
        {
            var listPostImages = new List<PostImage>();

            var mockRepo = new Mock<IDeletableEntityRepository<PostImage>>();

            mockRepo.Setup(x => x.All()).Returns(listPostImages.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<PostImage>())).Callback((PostImage x) => listPostImages.Add(x));
            mockRepo.Setup(x => x.HardDelete(It.IsAny<PostImage>())).Callback((PostImage x) => listPostImages.Remove(x));

            var postImageService = new PostImageService(mockRepo.Object);
            var paths = new string[] { "path1", "path2" };
            await postImageService.CreatingPostImageAsync(paths, 1);
            foreach (var postImage in listPostImages)
            {
                postImage.PostId = 1;
            }

            Assert.True(listPostImages.Any());
            await postImageService.HardDeletePostImagesByIdAsync(1);
            Assert.True(listPostImages.Any() == false);
        }
    }
}
