namespace SiteX.Services.Data.Tests.Shop.ProductSizeTest
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

    public class Create
    {
        [Fact]
        public async Task CreateProductSizeShouldGetCreated()
        {
            var listProductSizes = new List<ProductSize>();

            var mockRepo = new Mock<IDeletableEntityRepository<ProductSize>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(listProductSizes.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<ProductSize>())).Callback((ProductSize x) => listProductSizes.Add(x));

            var productSizeService = new ProductSizeService(mockRepo.Object);
            var sizes = new int[] { 1, 2 };

            await productSizeService.CreatingProductSizeAsync(sizes, Guid.NewGuid());

            Assert.NotEmpty(listProductSizes);
            Assert.Contains(listProductSizes, x => x.SizeId == 1);
            Assert.Contains(listProductSizes, x => x.SizeId == 2);
        }
    }
}
