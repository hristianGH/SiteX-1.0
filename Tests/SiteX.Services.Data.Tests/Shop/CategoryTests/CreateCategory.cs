using Moq;
using SiteX.Data.Common.Repositories;
using SiteX.Data.Models.Shop;
using SiteX.Services.Data.ShopService;
using SiteX.Web.ViewModels.ShopViewModels.CategoryModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SiteX.Services.Data.Tests.Shop.CategoryTests
{
    public class CreateCategory
    {
        [Fact]
        public async Task CreateShouldCreateName()
        {
            var list = new List<Category>();

            var mockRepo = new Mock<IRepository<Category>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Category>())).Callback((Category x) => list.Add(x));
            var service = new CategoryService(mockRepo.Object);

            var name = "Test Category";
            var category = new Category() {Id=1, Name = name };

            await service.CreateAsync(category);

            Assert.True(list.Count() > 0);
            Assert.Equal(name, list[0].Name);
        }


    }
}
