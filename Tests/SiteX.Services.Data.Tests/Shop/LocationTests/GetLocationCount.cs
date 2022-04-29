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

namespace SiteX.Services.Data.Tests.Shop.LocationTests
{
    public class GetLocationCount
    {
        [Fact]
        public async Task LocationsCountShouldReturnValue()
        {
            var list = new List<Location>();

            var mockRepo = new Mock<IRepository<Location>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Location>())).Callback((Location x) => list.Add(x));
            var service = new LocationService(mockRepo.Object);

            for (int i = 0; i < 4; i++)
            {
                list.Add(new Location() { Name = "Name", Address = "Address" });
            }
            var count = service.GetLocations().Count();
            Assert.True(count == 4);
        }
    }
}
