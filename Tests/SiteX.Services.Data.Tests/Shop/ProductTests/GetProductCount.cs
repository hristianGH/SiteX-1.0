namespace SiteX.Services.Data.Tests.Shop.ProductTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Moq;
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService;
    using SiteX.Web.ViewModels.ShopViewModels.ProductModels;
    using Xunit;

    public class GetProductCount
    {
        [Fact]
        public async Task GetProductCountShoudReturnValue()
        {
            var list = new List<Product>();

            var mockProductRepo = new Mock<IDeletableEntityRepository<Product>>();

            mockProductRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockProductRepo.Setup(x => x.AddAsync(It.IsAny<Product>())).Callback((Product x) => list.Add(x));
            var service = new ProductService(mockProductRepo.Object);
            for (int i = 0; i < 3; i++)
            {
                var product = new ProductViewModel()
                {
                    Name = $"Big Shirt {i}",
                    Price = 120,
                    Gender = "Unisex",
                    Locations = new int[] { 1 },
                    Sizes = new int[] { 1, 2 },
                    Pictures = new string[] { "image1", "image2" },
                    Quantity = 22,
                    Description = "Product",
                };

                await service.CreateAsync(product);
            }

            var count = service.GetProductCount();
            Assert.True(count == 3);
        }
    }
}
