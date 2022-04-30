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

    public class GetById
    {
        [Fact]
        public async Task GetByIdShouldReturnValue()
        {
            var list = new List<Genre>();

            var mockRepo = new Mock<IRepository<Genre>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Genre>())).Callback((Genre x) => list.Add(x));
            var service = new GenreService(mockRepo.Object);

            for (int i = 0; i <= 3; i++)
            {
                var genre = new GenreViewModel()
                {
                    Name = $"Test Genre {i}",
                };
                await service.CreateAsync(genre);
                list[i].Id = i;
            }

            var byId = service.GetGenreById(3);

            Assert.True(byId.Name == $"Test Genre {3}");
        }

        [Fact]
        public async Task GetByIdShouldReturnValueWithId()
        {
            var list = new List<Genre>();

            var mockRepo = new Mock<IRepository<Genre>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Genre>())).Callback((Genre x) => list.Add(x));
            var service = new GenreService(mockRepo.Object);

            for (int i = 0; i <= 3; i++)
            {
                var genre = new GenreViewModel()
                {
                    Name = $"Test Genre {i}",
                };
                await service.CreateAsync(genre);
                list[i].Id = i;
            }

            var byId = service.GetGenreById(3);

            Assert.True(byId.Id == 3);
        }
    }
}
