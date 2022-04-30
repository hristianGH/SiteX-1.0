namespace SiteX.Services.Data.Tests.Shop.ProductImageTests
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
            var listProductImages = new List<ProductImage>();

            var mockRepo = new Mock<IDeletableEntityRepository<ProductImage>>();

            mockRepo.Setup(x => x.All()).Returns(listProductImages.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<ProductImage>())).Callback((ProductImage x) => listProductImages.Add(x));
            mockRepo.Setup(x => x.HardDelete(It.IsAny<ProductImage>())).Callback((ProductImage x) => listProductImages.Remove(x));
            var productId = Guid.NewGuid();

            var productImageService = new ProductImageService(mockRepo.Object);
            var paths = new string[] { "image1" };

            await productImageService.CreatingProductImageAsync(paths, productId);

            Assert.True(listProductImages.Any());
            await productImageService.HardDeleteProductImagesByIdAsync(productId);
            Assert.True(listProductImages.Any() == false);
        }
    }
}
