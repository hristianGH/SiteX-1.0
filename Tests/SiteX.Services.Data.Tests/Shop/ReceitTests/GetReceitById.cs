namespace SiteX.Services.Data.Tests.Shop.ReceitTests
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

    public class GetReceitById
    {
        [Fact]
        public async Task GetReceitByIdShouldReturnReceitWithTheSameId()
        {
            var list = new List<Receit>();

            var mockProductRepo = new Mock<IRepository<Receit>>();

            mockProductRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());

            mockProductRepo.Setup(x => x.AddAsync(It.IsAny<Receit>())).Callback((Receit x) => list.Add(x));
            mockProductRepo.Setup(x => x.Delete(It.IsAny<Receit>())).Callback((Receit x) => list.Remove(x));
            var service = new ReceitService(mockProductRepo.Object);
            var firstId = Guid.NewGuid();
            for (int i = 0; i < 3; i++)
            {
                var receit = new Receit() { ProductId = Guid.NewGuid(), Price = 12, ProductName = "Test" };

                await service.CreateAsync(receit);
            }

            list.First().Id = firstId;

            Assert.NotEmpty(list);
            Assert.True(list[1].ProductName == "Test");
            Assert.True(list[1].Price == 12);

            var byId = service.GetById(firstId);
            Assert.True(byId.Price == 12);
            Assert.True(byId.ProductName == "Test");
        }
    }
}
