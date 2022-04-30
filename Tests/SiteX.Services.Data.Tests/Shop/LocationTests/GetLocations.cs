namespace SiteX.Services.Data.Tests.Shop.LocationTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Moq;
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService;
    using Xunit;

    public class GetLocations
    {
        [Fact]
        public void GetLocationsShouldReturnValue()
        {
            var list = new List<Location>();

            var mockRepo = new Mock<IRepository<Location>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Location>())).Callback((Location x) => list.Add(x));
            var service = new LocationService(mockRepo.Object);

            for (int i = 0; i < 10; i++)
            {
                list.Add(new Location() { Id = i, Name = "Name" });
            }

            var result = service.GetLocations();

            Assert.True(result.Count() == 10);
        }
    }
}
