namespace SiteX.Services.Data.Tests.Blog.GenreTests
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

    public class Create
    {
        [Fact]
        public async Task CreateGenreShouldCreateName()
        {
            var list = new List<Genre>();

            var mockRepo = new Mock<IRepository<Genre>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Genre>())).Callback((Genre x) => list.Add(x));
            var service = new GenreService(mockRepo.Object);

            var name = "Test Genre";
            var genre = new GenreViewModel() { Name = name };

            await service.CreateAsync(genre);

            Assert.True(list.Count() > 0);
            Assert.Equal(name, list[0].Name);
        }
    }
}
