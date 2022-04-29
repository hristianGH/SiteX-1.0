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
    public class EditLocation
    {

        [Fact]
        public async Task LocationEditShouldChangeValue()
        {
            var list = new List<Location>();

            var mockRepo = new Mock<IRepository<Location>>();

            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Location>())).Callback((Location x) => list.Add(x));
            var service = new LocationService(mockRepo.Object);

            var oldName = "Before Edit";
            var name = "After Edit";
            var oldAddress = "Before Address";
            var address = "After Address";
            var location = new Location() { Id = 1, Name = oldName,Address=oldAddress };
            list.Add(location);

            var locationEdit = new Location() { Id = 1, Name = name,Address=address };
            await service.EditAsync(locationEdit);

            Assert.Equal(name, list[0].Name);
            Assert.Equal(address, list[0].Address);

        }

    }
}
