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
    public class Create
    {
        [Fact]
        public async Task CreateProductColorShouldGetCreated()
        {

            var listProductCategory = new List<ProductColor>();

            var mockRepo = new Mock<IDeletableEntityRepository<ProductColor>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(listProductCategory.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<ProductColor>())).Callback((ProductColor x) => listProductCategory.Add(x));

            var productCategoryService = new ProductColorService(mockRepo.Object);
            var categories = new int[] { 1, 2 };

            await productCategoryService.CreatingProductColorAsync(categories, Guid.NewGuid());

            Assert.True(listProductCategory.Count() > 0);
            Assert.Contains(listProductCategory, x => x.ColorId == 1);
            Assert.Contains(listProductCategory, x => x.ColorId == 2);
        }
    }
}
