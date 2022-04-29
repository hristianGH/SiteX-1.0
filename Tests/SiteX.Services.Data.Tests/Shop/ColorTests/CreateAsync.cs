using Moq;
using SiteX.Data.Common.Repositories;
using SiteX.Data.Models.Shop;
using SiteX.Services.Data.ShopService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SiteX.Services.Data.Tests.Shop.ColorTests
{
    public class CreateAsync
    {
        [Fact]
        public async Task CreateColorShouldCreateName()
        {
            var list = new List<Color>();

            var mockRepo = new Mock<IRepository<Color>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Color>())).Callback((Color x) => list.Add(x));
            var service = new ColorService(mockRepo.Object);

            var name = "Test Color";
            var color = new Color() { Id = 1, Name = name };

            await service.CreateAsync(color);

            Assert.True(list.Count() > 0);
            Assert.Equal(name, list[0].Name);
        }
    }
}
