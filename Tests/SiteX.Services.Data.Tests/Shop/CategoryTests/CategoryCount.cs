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

namespace SiteX.Services.Data.Tests.Shop.CategoryTests
{
    public class CategoryCount
    {
        [Fact]
        public async Task CategoryCountShouldReturnValue()
        {
            var list = new List<Category>();

            var mockRepo = new Mock<IRepository<Category>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Category>())).Callback((Category x) => list.Add(x));
            var service = new CategoryService(mockRepo.Object);

            for (int i = 0; i < 4; i++)
            {
                list.Add(new Category() { Name = "Name" });
            }
            var count = service.GetCategoryCount();
            Assert.True(count == 4);
        }
    }
}
