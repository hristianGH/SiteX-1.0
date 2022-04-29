using Moq;
using SiteX.Data.Common.Repositories;
using SiteX.Data.Models.Blog;
using SiteX.Services.Data.BlogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SiteX.Services.Data.Tests.Blog.PostImageTests
{
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

            Assert.True(listPosts.Count() > 0);
            Assert.True(listPosts.Any(x => x.Path == "path1"));
            Assert.True(listPosts.Any(x => x.Path == "path2"));
        }
    }
}
