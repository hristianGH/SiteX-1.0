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
using System.Threading.Tasks;
using Xunit;

namespace SiteX.Services.Data.Tests.Shop.ProductTests
{
    public class ReturnAll
    {
        [Fact]
        public async Task ToPageSholdReturnProducts()
        {
            var list = new List<Product>();

            if (AutoMapperConfig.MapperInstance == null)
            {
                AutoMapperConfig.RegisterMappings(typeof(IndexViewModel).GetTypeInfo().Assembly);
            }

            var mockProductRepo = new Mock<IDeletableEntityRepository<Product>>();

            mockProductRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());

            mockProductRepo.Setup(x => x.AddAsync(It.IsAny<Product>())).Callback((Product x) => list.Add(x));

            var service = new ProductService(mockProductRepo.Object);
            var guid = Guid.NewGuid();
            for (int i = 0; i < 3; i++)
            {
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
                    Id = guid,
                    Description = "Product",

                };
                await service.CreateAsync(product);
                list[i].Id = guid;
                guid = Guid.NewGuid();
            }
            var all = service.ReturnAll();

            Assert.NotNull(all);
            Assert.True(all.Count() == 3);
        }
    }
}
