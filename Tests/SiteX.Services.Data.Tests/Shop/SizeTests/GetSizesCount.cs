using Moq;
using SiteX.Data.Common.Repositories;
using SiteX.Data.Models.Shop;
using SiteX.Services.Data.ShopService;
using SiteX.Web.ViewModels.ShopViewModels.SizeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SiteX.Services.Data.Tests.Shop.SizeTests
{
    public class GetSizesCount
    {
        [Fact]
        public async Task GetSizesCountShoudReturnCountFromRepository()
        {
            var listSize = new List<Size>();

            var mockRepo = new Mock<IRepository<Size>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(listSize.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Size>())).Callback((Size x) => listSize.Add(x));

            var sizeService = new SizeService(mockRepo.Object);
            var size = new SizeViewModel()
            {
                Name = "Test",
            };
            await sizeService.CreateAsync(size);
            Assert.True(sizeService.GetSizesCount() > 0);
            Assert.Contains(listSize, x => x.Name == "Test");
        }
    }
}
