namespace SiteX.Services.Data.Tests.Blog.PostGenreTests
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
        public async Task CreatePostGenreShouldGetCreated()
        {
            var listPosts = new List<PostGenre>();

            var mockRepo = new Mock<IDeletableEntityRepository<PostGenre>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(listPosts.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<PostGenre>())).Callback((PostGenre x) => listPosts.Add(x));

            var postGenreService = new PostGenreSevice(mockRepo.Object);
            var paths = new int[] { 1, 2 };

            await postGenreService.CreatingPostGenreAsync(paths, 1);

            Assert.True(listPosts.Count() > 0);
            Assert.Contains(listPosts, x => x.GenreId == 1);
            Assert.Contains(listPosts, x => x.GenreId == 2);
        }
    }
}
