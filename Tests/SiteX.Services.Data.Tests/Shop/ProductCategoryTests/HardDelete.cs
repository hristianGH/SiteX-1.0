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

namespace SiteX.Services.Data.Tests.Shop.ProductCategoryTests
{
    public class HardDelete
    {
        [Fact]
        public async Task HardDeleteProductCategoryShouldRemoveItemsFromRepository()
        {

            var listPostImages = new List<ProductCategory>();

            var mockRepo = new Mock<IDeletableEntityRepository<ProductCategory>>();

            mockRepo.Setup(x => x.All()).Returns(listPostImages.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<ProductCategory>())).Callback((ProductCategory x) => listPostImages.Add(x));
            mockRepo.Setup(x => x.HardDelete(It.IsAny<ProductCategory>())).Callback((ProductCategory x) => listPostImages.Remove(x));
            var productId = Guid.NewGuid();

            var postImageService = new ProductCategoryService(mockRepo.Object);
            var paths = new int[] { 1 };
            await postImageService.CreatingProductCategoryAsync(paths, productId);
            foreach (var postImage in listPostImages)
            {
                postImage.CategoryId = 1;
            }
            Assert.True(listPostImages.Any());
            await postImageService.HardDeleteProductCategoriesByIdAsync(productId);
            Assert.True(listPostImages.Any() == false);

        }
    }
}
