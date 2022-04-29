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
    public class GetSizes
    {
        [Fact]
        public async Task GetSizesShouldReturnSizesFromRepository()
        {

            var listSize = new List<Size>();

            var mockRepo = new Mock<IRepository<Size>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(listSize.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Size>())).Callback((Size x) => listSize.Add(x));

            var sizeService = new SizeService(mockRepo.Object);
            for (int i = 0; i < 3; i++)
            {
                var size = new SizeViewModel()
                {
                    Name = "Test",
                };
                await sizeService.CreateAsync(size);
            }
            var getSizes = sizeService.GetSizes();
            Assert.True(listSize.Count() == 3);
            Assert.True(getSizes.Count() == 3);
            Assert.True(getSizes.Any(x => x.Name != "Test") == false);
        }
    }
}

