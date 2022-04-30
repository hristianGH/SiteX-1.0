﻿namespace SiteX.Services.Data.Tests.Shop.ProductTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Moq;
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService;
    using SiteX.Web.ViewModels.ShopViewModels.ProductModels;
    using Xunit;

    public class DeleteProduct
    {
        [Fact]
        public async Task RemoveProductRemoves()
        {
            var list = new List<Product>();

            var mockProductRepo = new Mock<IDeletableEntityRepository<Product>>();

            mockProductRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockProductRepo.Setup(x => x.AddAsync(It.IsAny<Product>())).Callback((Product x) => list.Add(x));
            mockProductRepo.Setup(x => x.Delete(It.IsAny<Product>())).Callback((Product x) => x.IsDeleted = true);
            var guid = Guid.NewGuid();

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
                Id = guid,
                Description = "Product",
            };

            await service.CreateAsync(product);

            Assert.True(list.Count() > 0);
            Assert.True(list[0].Name == "Big Shirt");
            Assert.True(list[0].Price == 12);
            Assert.True(list[0].Gender == "Unisex");
            Assert.True(list[0].ProductCategories.Count() == 3);
            Assert.True(list[0].ProductLocations.Count() == 1);
            Assert.True(list[0].ProductColors.Count() == 2);
            Assert.True(list[0].ProductSizes.Count() == 2);
            Assert.True(list[0].Quantity == 22);

            await service.RemoveProductAsync(list.FirstOrDefault());
            Assert.True(list.FirstOrDefault().IsAvalable == false);
            Assert.True(list.FirstOrDefault().IsDeleted == true);
        }

        [Fact]
        public async Task SoftDeleteSholdDeleteEntity()
        {
            var list = new List<Product>();

            var mockProductRepo = new Mock<IDeletableEntityRepository<Product>>();

            mockProductRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockProductRepo.Setup(x => x.AddAsync(It.IsAny<Product>())).Callback((Product x) => list.Add(x));
            mockProductRepo.Setup(x => x.Delete(It.IsAny<Product>())).Callback((Product x) => x.IsDeleted = true);
            var guid = Guid.NewGuid();

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
                Id = guid,
                Description = "Product",
            };

            await service.CreateAsync(product);
            list[0].Id = guid;
            Assert.NotEmpty(list);
            Assert.True(list[0].Name == "Big Shirt");
            Assert.True(list[0].Price == 12);
            Assert.True(list[0].Gender == "Unisex");
            Assert.True(list[0].ProductCategories.Count() == 3);
            Assert.True(list[0].ProductLocations.Count() == 1);
            Assert.True(list[0].ProductColors.Count() == 2);
            Assert.True(list[0].ProductSizes.Count() == 2);
            Assert.True(list[0].Quantity == 22);

            await service.SoftDeleteProductByIdAsync(guid);
            Assert.True(list.FirstOrDefault().IsAvalable == false);
            Assert.True(list.FirstOrDefault().IsDeleted == true);
        }
    }
}
