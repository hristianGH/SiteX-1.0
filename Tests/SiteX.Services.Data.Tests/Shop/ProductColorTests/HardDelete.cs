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

namespace SiteX.Services.Data.Tests.Shop.ProductColorTests
{
    public class HardDelete
    {
        [Fact]
        public async Task HardDeleteProductColorShouldRemoveItemsFromRepository()
        {

            var listPostImages = new List<ProductColor>();

            var mockRepo = new Mock<IDeletableEntityRepository<ProductColor>>();

            mockRepo.Setup(x => x.All()).Returns(listPostImages.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<ProductColor>())).Callback((ProductColor x) => listPostImages.Add(x));
            mockRepo.Setup(x => x.HardDelete(It.IsAny<ProductColor>())).Callback((ProductColor x) => listPostImages.Remove(x));
            var productId = Guid.NewGuid();

            var postImageService = new ProductColorService(mockRepo.Object);
            var paths = new int[] { 1 };
            await postImageService.CreatingProductColorAsync(paths, productId);
            

            Assert.True(listPostImages.Any());
            await postImageService.HardDeleteProductColorByIdAsync(productId);
            Assert.True(listPostImages.Any() == false);

        }
    }
}
