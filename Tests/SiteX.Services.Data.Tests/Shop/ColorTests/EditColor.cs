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

namespace SiteX.Services.Data.Tests.Shop.ColorTests
{
    public class EditLocation
    {

        [Fact]
        public async Task ColorEditSholdChangeName()
        {
            var list = new List<Color>();

            var mockRepo = new Mock<IRepository<Color>>();

            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Color>())).Callback((Color x) => list.Add(x));
            var service = new ColorService(mockRepo.Object);

            var oldName = "Before Edit";
            var name = "After Edit";
            var color = new Color() { Id = 1, Name = oldName };
            list.Add(color);

            var colorEdit = new Color() { Id = 1, Name = name };
            await service.EditColorAsync(colorEdit);

            Assert.Equal(name, list[0].Name);
        }

    }
}
