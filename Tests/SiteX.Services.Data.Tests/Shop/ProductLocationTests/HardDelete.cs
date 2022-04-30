namespace SiteX.Services.Data.Tests.Shop.ProductLocationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Moq;
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService;
    using Xunit;

    public class HardDelete
    {
        [Fact]
        public async Task HardDeleteProductImageShouldRemoveItemsFromRepository()
        {
            var listProductLocations = new List<ProductLocation>();

            var mockRepo = new Mock<IDeletableEntityRepository<ProductLocation>>();

            mockRepo.Setup(x => x.All()).Returns(listProductLocations.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<ProductLocation>())).Callback((ProductLocation x) => listProductLocations.Add(x));
            mockRepo.Setup(x => x.HardDelete(It.IsAny<ProductLocation>())).Callback((ProductLocation x) => listProductLocations.Remove(x));
            var productId = Guid.NewGuid();

            var productLocationService = new ProductLocationService(mockRepo.Object);
            var locations = new int[] { 1, 2 };

            await productLocationService.CreatingProductLocationAsync(locations, productId);

            Assert.True(listProductLocations.Any());
            await productLocationService.HardDeleteProductLocationByIdAsync(productId);
            Assert.True(listProductLocations.Any() == false);
        }
    }
}
