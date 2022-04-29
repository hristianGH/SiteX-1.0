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
            var sizes = new int[] {1,2};

            await productSizeService.CreatingProductSizeAsync(sizes, Guid.NewGuid());

            Assert.True(listProductSizes.Count() > 0);
            Assert.Contains(listProductSizes, x => x.SizeId == 1);
            Assert.Contains(listProductSizes, x => x.SizeId == 2);
        }
    }
}
