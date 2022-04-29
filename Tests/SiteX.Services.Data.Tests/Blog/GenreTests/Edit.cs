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
    public class Edit
    {
        [Fact]
        public async Task EditGenreShouldEditGenreName()
        {
            var list = new List<Genre>();

            var mockRepo = new Mock<IRepository<Genre>>();

            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Genre>())).Callback((Genre x) => list.Add(x));
            var service = new GenreService(mockRepo.Object);

            for (int i = 0; i <= 3; i++)
            {
                var genre = new GenreViewModel()
                {
                    Name = $"Test Genre {i}"
                };
                await service.CreateAsync(genre);
                list[i].Id = i;
            }

            await service.EditAsync(new Genre { Id = 3, Name = $"Edited Genre" });

            Assert.True(list.Any(x => x.Name == "Edited Genre"));
        }

        [Fact]
        public async Task EditGenreShouldBeOnTheSameId()
        {
            var list = new List<Genre>();

            var mockRepo = new Mock<IRepository<Genre>>();

            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Genre>())).Callback((Genre x) => list.Add(x));
            var service = new GenreService(mockRepo.Object);

            for (int i = 0; i <= 3; i++)
            {
                var genre = new GenreViewModel()
                {
                    Name = $"Test Genre {i}"
                };
                await service.CreateAsync(genre);
                list[i].Id = i;
            }

            await service.EditAsync(new Genre { Id = 3, Name = $"Edited Genre" });

            Assert.True(list.Any(x => x.Name == "Edited Genre"));
            Assert.True(list.Where(x => x.Name == "Edited Genre" && x.Id == 3).Any());
        }
    }
}
