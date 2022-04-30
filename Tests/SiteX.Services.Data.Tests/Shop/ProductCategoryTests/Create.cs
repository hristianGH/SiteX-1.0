namespace SiteX.Services.Data.Tests.Shop.ProductCategoryTests
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
        public async Task CreatePostCategoryShouldAddToRepository()
        {
            var listProductCategory = new List<ProductCategory>();

            var mockRepo = new Mock<IDeletableEntityRepository<ProductCategory>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(listProductCategory.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<ProductCategory>())).Callback((ProductCategory x) => listProductCategory.Add(x));

            var productCategoryService = new ProductCategoryService(mockRepo.Object);
            var categories = new int[] { 1, 2 };

            await productCategoryService.CreatingProductCategoryAsync(categories, Guid.NewGuid());

            Assert.True(listProductCategory.Count() > 0);
            Assert.Contains(listProductCategory, x => x.CategoryId == 1);
            Assert.Contains(listProductCategory, x => x.CategoryId == 2);
        }
    }
}
