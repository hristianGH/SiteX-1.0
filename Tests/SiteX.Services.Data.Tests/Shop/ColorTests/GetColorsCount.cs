namespace SiteX.Services.Data.Tests.Shop.ColorTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Moq;
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService;
    using Xunit;

    public class GetColorsCount
    {
        [Fact]
        public void ColorsCountShouldReturnValue()
        {
            var list = new List<Color>();

            var mockRepo = new Mock<IRepository<Color>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Color>())).Callback((Color x) => list.Add(x));
            var service = new ColorService(mockRepo.Object);

            for (int i = 0; i < 4; i++)
            {
                list.Add(new Color() { Name = "Name" });
            }

            var count = service.GetColorsCount();
            Assert.True(count == 4);
        }
    }
}
