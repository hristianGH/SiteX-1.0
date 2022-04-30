namespace SiteX.Services.Data.Tests.Blog.PostListTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Moq;
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Blog;
    using SiteX.Services.Data.BlogService;
    using SiteX.Web.ViewModels.BlogViewModels;
    using Xunit;

    public class ToSelectedList
    {
        [Fact]
        public async Task ToSelectedListShouldReturnValues()
        {
            var listPosts = new List<PostGenre>();
            var listGenres = new List<Genre>();

            var mockRepo = new Mock<IDeletableEntityRepository<PostGenre>>();
            var mockGenre = new Mock<IRepository<Genre>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(listPosts.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<PostGenre>())).Callback((PostGenre x) => listPosts.Add(x));

            mockGenre.Setup(x => x.AllAsNoTracking()).Returns(listGenres.AsQueryable());
            mockGenre.Setup(x => x.AddAsync(It.IsAny<Genre>())).Callback((Genre x) => listGenres.Add(x));

            var genreService = new GenreService(mockGenre.Object);
            var postGenreService = new PostListService(genreService);

            for (int i = 0; i < 10; i++)
            {
                var name = "Test Genre";
                var genre = new GenreViewModel() { Name = name };

                await genreService.CreateAsync(genre);
            }

            var toSelectedList = postGenreService.ToSelectedList();

            Assert.True(toSelectedList.GenresToList.Any());
            Assert.True(toSelectedList.GenresToList.Count() == 10);
        }
    }
}
