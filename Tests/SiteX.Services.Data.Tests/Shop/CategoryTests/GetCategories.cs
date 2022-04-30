namespace SiteX.Services.Data.Tests.Shop.CategoryTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Moq;
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService;
    using Xunit;

    public class GetCategories
    {
        [Fact]
        public void GetCategoriesShouldReturnValue()
        {
            var list = new List<Category>();

            var mockRepo = new Mock<IRepository<Category>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Category>())).Callback((Category x) => list.Add(x));
            var service = new CategoryService(mockRepo.Object);

            for (int i = 0; i < 10; i++)
            {
                list.Add(new Category() { Id = i, Name = "Name" });
            }

            var result = service.GetCategories();

            Assert.True(result.Count() == 10);
        }
    }
}
