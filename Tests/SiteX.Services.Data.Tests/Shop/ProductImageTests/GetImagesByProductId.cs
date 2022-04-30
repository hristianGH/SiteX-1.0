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

    public class GetImagesByProductId
    {
        [Fact]
        public async Task CreateProductImageShouldGetCreated()
        {
            var listProductImages = new List<ProductImage>();

            var mockRepo = new Mock<IDeletableEntityRepository<ProductImage>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(listProductImages.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<ProductImage>())).Callback((ProductImage x) => listProductImages.Add(x));
            var productId = Guid.NewGuid();

            var productImageService = new ProductImageService(mockRepo.Object);
            var images = new string[] { "image1", "image2", "image3", "image4" };

            await productImageService.CreatingProductImageAsync(images, productId);

            var productImages = productImageService.GetImagesByProductId(productId);

            Assert.NotNull(productImages);
            Assert.True(productImages.Count() == 4);
            Assert.Contains(productImages, x => x.Path == "image1");
            Assert.Contains(productImages, x => x.Path == "image2");
            Assert.Contains(productImages, x => x.Path == "image3");
            Assert.Contains(productImages, x => x.Path == "image4");
        }
    }
}
