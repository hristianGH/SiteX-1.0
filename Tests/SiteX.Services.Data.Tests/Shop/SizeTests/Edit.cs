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

    public class Edit
    {
        [Fact]
        public async Task EditSizeShouldEditSizeFromRepository()
        {
            var listSize = new List<Size>();

            var mockRepo = new Mock<IRepository<Size>>();

            mockRepo.Setup(x => x.All()).Returns(listSize.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Size>())).Callback((Size x) => listSize.Add(x));

            var sizeService = new SizeService(mockRepo.Object);
            var size = new SizeViewModel()
            {
                Name = "Test",
            };
            await sizeService.CreateAsync(size);
            listSize.First().Id = 1;
            var edit = new Size() { Id = 1, Name = "Edited" };
            await sizeService.EditSizeAsync(edit);

            Assert.True(listSize.Count == 1);
            Assert.Contains(listSize, x => x.Id == 1 && x.Name == "Edited");
        }
    }
}
