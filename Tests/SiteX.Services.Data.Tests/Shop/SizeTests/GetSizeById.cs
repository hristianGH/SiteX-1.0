namespace SiteX.Services.Data.Tests.Shop.SizeTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Moq;
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService;
    using SiteX.Web.ViewModels.ShopViewModels.SizeModels;
    using Xunit;

    public class GetSizeById
    {
        [Fact]
        public async Task GetSizeByIdShoudReturnSizeByIdWithValue()
        {
            var listSize = new List<Size>();

            var mockRepo = new Mock<IRepository<Size>>();

            mockRepo.Setup(x => x.All()).Returns(listSize.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Size>())).Callback((Size x) => listSize.Add(x));

            var sizeService = new SizeService(mockRepo.Object);
            for (int i = 0; i < 3; i++)
            {
                var size = new SizeViewModel()
                {
                    Name = $"Test {i}",
                };
                await sizeService.CreateAsync(size);
                listSize[i].Id = i;
            }

            var sizeById = sizeService.GetSizeById(1);
            Assert.NotNull(sizeById);
            Assert.True(sizeById.Id == 1);
            Assert.True(sizeById.Name == "Test 1");
        }
    }
}
