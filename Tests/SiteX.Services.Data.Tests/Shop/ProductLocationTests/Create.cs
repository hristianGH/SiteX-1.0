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

namespace SiteX.Services.Data.Tests.Shop.ProductLocationTests
{
    public class Create
    {
        [Fact]
        public async Task CreateProductLocationShouldGetCreated()
        {
            var listProductLocations = new List<ProductLocation>();

            var mockRepo = new Mock<IDeletableEntityRepository<ProductLocation>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(listProductLocations.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<ProductLocation>())).Callback((ProductLocation x) => listProductLocations.Add(x));

            var productImageService = new ProductLocationService(mockRepo.Object);
            var locations = new int[] {1,2};

            await productImageService.CreatingProductLocationAsync(locations, Guid.NewGuid());

            Assert.True(listProductLocations.Count() > 0);
            Assert.Contains(listProductLocations, x => x.LocationId == 1);
            Assert.Contains(listProductLocations, x => x.LocationId == 2);
        }
    }
}
