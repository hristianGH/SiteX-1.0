using Moq;
using SiteX.Data.Common.Repositories;
using SiteX.Data.Models.Shop;
using SiteX.Services.Data.ShopService;
using SiteX.Services.Mapping;
using SiteX.Web.ViewModels;
using SiteX.Web.ViewModels.ShopViewModels.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SiteX.Services.Data.Tests.Shop.ProductTests
{
    public class GetProductById
    {

        [Fact]
        public async Task GetProductByIdShouldReturnProductByThatId()
        {
            var list = new List<Product>();

            var mockProductRepo = new Mock<IDeletableEntityRepository<Product>>();

            mockProductRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockProductRepo.Setup(x => x.AddAsync(It.IsAny<Product>())).Callback((Product x) => list.Add(x));
            var service = new ProductService(mockProductRepo.Object);
            var guid = Guid.NewGuid();
            for (int i = 0; i < 5; i++)
            {

                var product = new ProductViewModel()
                {
                    Name = $"Big Shirt {i}",
                    Price = 120,
                    Gender = "Unisex",
                    Categories = new int[] { 1, 2, 3 },
                    Locations = new int[] { 1 },
                    Colors = new int[] { 1, 2 },
                    Sizes = new int[] { 1, 2 },
                    Pictures = new string[] { "image1", "image2" },
                    Quantity = 22,
                    Id = guid,
                    Description = "Product",

                };
                await service.CreateAsync(product);
                list[i].Id = guid;
                guid = Guid.NewGuid();
            }
            for (int i = 0; i < 5; i++)
            {
                var get = service.GetProductById(list[i].Id);
                Assert.True(get.Id == list[i].Id);
                Assert.True(get.Name == $"Big Shirt {i}");
            }
        }

        [Fact]
        public async Task GetOutputProductByIdShoudReturnOutputProduct()
        {
            var list = new List<Product>();

            var mockProductRepo = new Mock<IDeletableEntityRepository<Product>>();
            if (AutoMapperConfig.MapperInstance == null)
            {
                AutoMapperConfig.RegisterMappings(typeof(IndexViewModel).GetTypeInfo().Assembly);
            }

            mockProductRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockProductRepo.Setup(x => x.AddAsync(It.IsAny<Product>())).Callback((Product x) => list.Add(x));
            var service = new ProductService(mockProductRepo.Object);
            var guid = Guid.NewGuid();
            for (int i = 0; i < 5; i++)
            {

                var product = new ProductViewModel()
                {
                    Name = $"Big Shirt {i}",
                    Price = 120,
                    Gender = "Unisex",
                    Categories = new int[] { 1, 2, 3 },
                    Locations = new int[] { 1 },
                    Colors = new int[] { 1, 2 },
                    Sizes = new int[] { 1, 2 },
                    Pictures = new string[] { "image1", "image2" },
                    Quantity = 22,
                    Id = guid,
                    Description = "Product",

                };
                await service.CreateAsync(product);
                list[i].Id = guid;
                guid = Guid.NewGuid();
            }
            for (int i = 0; i < 5; i++)
            {
                var get = service.GetOutputProductById(list[i].Id);
                Assert.True(get.Id == list[i].Id);
                Assert.True(get.Name == $"Big Shirt {i}");
                Assert.True(get.ImageUrl == "image1");
                Assert.True(get.Gender == "Unisex");
                Assert.True(get.Price == 120);
                Assert.True(get.Quantity == 22);
                Assert.True(get.Description == "Product");
                Assert.True(get.Categories.Count == 3);
                Assert.True(get.Locations.Count == 1);
                Assert.True(get.Colors.Count == 2);
                Assert.True(get.Sizes.Count == 2);
            }
        }
    }
}
