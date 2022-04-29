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

namespace SiteX.Services.Data.Tests.Shop.GenderTests
{
    public class GetGenders
    {
        [Fact]
        public async Task GetGendersShouldReturnValue()
        {
            var list = new List<Gender>();

            var mockRepo = new Mock<IRepository<Gender>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Gender>())).Callback((Gender x) => list.Add(x));
            var service = new GenderService(mockRepo.Object);

            for (int i = 0; i < 10; i++)
            {
                list.Add(new Gender() { Id = i, Name = "Name" });
            }

            var result = service.GetGenders();

            Assert.True(result.Count() == 10);
        }
    }
}
