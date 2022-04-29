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

namespace SiteX.Services.Data.Tests.Shop.ProductSizeTest
{
    public class HardDelete
    {
        [Fact]
        public async Task HardDeleteProductSizeShouldRemoveItemsFromRepository()
        {
            var listProductSizes = new List<ProductSize>();

            var mockRepo = new Mock<IDeletableEntityRepository<ProductSize>>();

            mockRepo.Setup(x => x.All()).Returns(listProductSizes.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<ProductSize>())).Callback((ProductSize x) => listProductSizes.Add(x));
            mockRepo.Setup(x => x.HardDelete(It.IsAny<ProductSize>())).Callback((ProductSize x) => listProductSizes.Remove(x));
            var productId = Guid.NewGuid();

            var productSizeService = new ProductSizeService(mockRepo.Object);
            var sizes = new int[] { 1, 2 };

            await productSizeService.CreatingProductSizeAsync(sizes, productId);

            Assert.True(listProductSizes.Any());
            await productSizeService.HardDeleteProductSizeByIdAsync(productId);
            Assert.True(listProductSizes.Any() == false);
        }
    }
}
