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

    public class Create
    {
        [Fact]
        public async Task CreateProductImageShouldGetCreated()
        {
            var listProductImages = new List<ProductImage>();

            var mockRepo = new Mock<IDeletableEntityRepository<ProductImage>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(listProductImages.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<ProductImage>())).Callback((ProductImage x) => listProductImages.Add(x));

            var productImageService = new ProductImageService(mockRepo.Object);
            var images = new string[] { "image1", "image2" };

            await productImageService.CreatingProductImageAsync(images, Guid.NewGuid());

            Assert.True(listProductImages.Count() > 0);
            Assert.Contains(listProductImages, x => x.Path == "image1");
            Assert.Contains(listProductImages, x => x.Path == "image2");
        }
    }
}
