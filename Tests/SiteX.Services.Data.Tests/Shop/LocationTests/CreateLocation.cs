using Moq;
using SiteX.Data.Common.Repositories;
using SiteX.Data.Models.Shop;
using SiteX.Services.Data.ShopService;
using SiteX.Web.ViewModels.ShopViewModels.LocationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SiteX.Services.Data.Tests.Shop.LocationTests
{
    public class CreateLocation
    {

        [Fact]
        public async Task GetColorsShouldReturnValue()
        {
            var list = new List<Location>();

            var mockRepo = new Mock<IRepository<Location>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Location>())).Callback((Location x) => list.Add(x));
            var service = new LocationService(mockRepo.Object);
            var model = new LocationViewModel()
            {
                Address = "Address",
                Name = "Name",
            };

          await  service.CreateAsync(model);


            Assert.True(list.Count() > 0);
            Assert.True(list.First().Address == "Address");
            Assert.True(list.First().Name == "Name");


        }
    }
}
