using Moq;
using SiteX.Data.Common.Repositories;
using SiteX.Data.Models.Shop;
using SiteX.Services.Data.ShopService;
using SiteX.Services.Data.ShopService.Interface;
using SiteX.Web.ViewModels.ShopViewModels.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SiteX.Services.Data.Tests.Shop.ProductTests
{
    public class CreateProduct
    {
        [Fact]
        public async Task CreateProductShouldWork()
        {
            var list = new List<Product>();

            var mockProductRepo = new Mock<IDeletableEntityRepository<Product>>();

            mockProductRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockProductRepo.Setup(x => x.AddAsync(It.IsAny<Product>())).Callback((Product x) => list.Add(x));
            var service = new ProductService(mockProductRepo.Object);

            var product = new ProductViewModel()
            {
                Name = "Big Shirt",
                Price = 12,
                Gender = "Unisex",
                Categories = new int[] { 1, 2, 3 },
                Locations = new int[] { 1 },
                Colors = new int[] { 1, 2 },
                Sizes = new int[] { 1, 2 },
                Pictures = new string[] { "image1", "image2" },
                Quantity = 22,
                Id = new Guid(),
                Description = "Product",

            };
            await service.CreateAsync(product);

            Assert.True(list.Count() > 0);
            Assert.True(list[0].Name == "Big Shirt");
            Assert.True(list[0].Price == 12);
            Assert.True(list[0].Gender == "Unisex");
            Assert.True(list[0].ProductCategories.Count()==3);
            Assert.True(list[0].ProductLocations.Count()==1);
            Assert.True(list[0].ProductColors.Count() == 2);
            Assert.True(list[0].ProductSizes.Count() == 2);
            Assert.True(list[0].Quantity == 22);

        }

    }
}
