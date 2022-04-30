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

    public class HardDelete
    {
        [Fact]
        public async Task HardDeleteShouldRemoveItemsFromRepository()
        {
            var listPostGenres = new List<PostGenre>();

            var mockRepo = new Mock<IDeletableEntityRepository<PostGenre>>();

            mockRepo.Setup(x => x.All()).Returns(listPostGenres.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<PostGenre>())).Callback((PostGenre x) => listPostGenres.Add(x));
            mockRepo.Setup(x => x.HardDelete(It.IsAny<PostGenre>())).Callback((PostGenre x) => listPostGenres.Remove(x));

            var postGenreService = new PostGenreSevice(mockRepo.Object);

            var paths = new int[] { 1 };

            await postGenreService.CreatingPostGenreAsync(paths, 1);

            Assert.True(listPostGenres.Count() > 0);
            Assert.Contains(listPostGenres, x => x.GenreId == 1);
            Assert.True(listPostGenres.Any());

            await postGenreService.HardDeletePostGenreByIdAsync(1);
            Assert.True(listPostGenres.Any() == false);
        }
    }
}
