using Moq;
using SiteX.Data.Common.Repositories;
using SiteX.Data.Models.Shop;
using SiteX.Services.Data.ShopService;
using SiteX.Web.ViewModels.ShopViewModels.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SiteX.Services.Data.Tests.Shop.ProductTests
{
    public class EditProduct
    {
        [Fact]
        public async Task EditProductShouldEditValuesAndConnections()
        {
            var list = new List<Product>();

            var mockProductRepo = new Mock<IDeletableEntityRepository<Product>>();

            mockProductRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockProductRepo.Setup(x => x.AddAsync(It.IsAny<Product>())).Callback((Product x) => list.Add(x));
            var service = new ProductService(mockProductRepo.Object);
            var guid = Guid.NewGuid();
            var product = new ProductViewModel()
            {
                Name = "Big Shirt",
                Price = 120,
                Gender = "Unisex",
                Categories = new int[] { 1, 2, 3 },
                Locations = new int[] { 1 },
                Colors = new int[] { 1, 2 },
                Sizes = new int[] { 1, 2 },
                Pictures = new string[] { "image1", "image2" },
                Quantity = 22,
                Id =guid,
                Description = "Product",

            };
            await service.CreateAsync(product);
            list[0].Id=guid;

            Assert.True(list.Count() > 0);
            Assert.True(list.First().Name == "Big Shirt");
            Assert.True(list.First().Price == 120);
            Assert.True(list.First().Gender == "Unisex");
            Assert.True(list.First().ProductCategories.Count() == 3);
            Assert.True(list.First().ProductLocations.Count() == 1);
            Assert.True(list.First().ProductColors.Count() == 2);
            Assert.True(list.First().ProductSizes.Count() == 2);
            Assert.True(list.First().Quantity == 22);

            var edit = new ProductViewModel()
            {
                Name = "Small Shirt",
                Price = 12,
                Gender = "Male",
                Categories = new int[] { 2, },
                Locations = new int[] { 1, 2 },
                Colors = new int[] { 1 },
                Sizes = new int[] { 1 },
                Pictures = new string[] { "image1", "image2" },
                Quantity = 1,
                Id = guid,
                Description = "New Product",
            };
            await service.EditProductAsync(edit);

            Assert.True(list.Count() > 0);
            Assert.True(list.First().Name == "Small Shirt");
            Assert.True(list.First().Price == 12);
            Assert.True(list.First().Gender == "Male");
            Assert.True(list.First().ProductCategories.Count() == 1);
            Assert.True(list.First().ProductLocations.Count() == 2);
            Assert.True(list.First().ProductColors.Count() == 1);
            Assert.True(list.First().ProductSizes.Count() == 1);
            Assert.True(list.First().Quantity == 1);
        }
    }
}
