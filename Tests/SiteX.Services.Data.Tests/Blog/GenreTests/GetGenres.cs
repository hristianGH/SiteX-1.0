using Moq;
using SiteX.Data.Common.Repositories;
using SiteX.Data.Models.Blog;
using SiteX.Services.Data.BlogService;
using SiteX.Web.ViewModels.BlogViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SiteX.Services.Data.Tests.Blog.GenreTests
{
    public class GetGenres
    {
        [Fact]
        public async Task GetGenresShouldReturnAllGenres()
        {
            var list = new List<Genre>();

            var mockRepo = new Mock<IRepository<Genre>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Genre>())).Callback((Genre x) => list.Add(x));
            var service = new GenreService(mockRepo.Object);

            for (int i = 0; i < 10; i++)
            {
                var name = "Test Genre";
                var genre = new GenreViewModel() { Name = name };

                await service.CreateAsync(genre);
            }
            var getAll = service.GetGenres();

            Assert.True(getAll.Count() == 10);

        }

        [Fact]
        public async Task GetGenresShouldReturnAllGenresWithNames()
        {
            var list = new List<Genre>();

            var mockRepo = new Mock<IRepository<Genre>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Genre>())).Callback((Genre x) => list.Add(x));
            var service = new GenreService(mockRepo.Object);

            for (int i = 0; i < 10; i++)
            {
                var name = "Test Genre";
                var genre = new GenreViewModel() { Name = name };

                await service.CreateAsync(genre);
            }

            var getAll = service.GetGenres();

            Assert.True(getAll.Count() == 10);
            Assert.True(getAll.Select(x => x.Name).All(x => x != null));
        }
    }
}
