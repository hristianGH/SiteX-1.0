namespace SiteX.Services.Data.Tests.Shop.ProductTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Moq;
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService;
    using SiteX.Services.Mapping;
    using SiteX.Web.ViewModels;
    using SiteX.Web.ViewModels.ShopViewModels.ProductModels;
    using Xunit;

    public class ProductFilters
    {
        [Fact]
        public async Task ProductFilterByCategorySholdFilter()
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
            for (int i = 0; i <= 3; i++)
            {
                var product = new ProductViewModel()
                {
                    Name = $"Big Shirt {i}",
                    Price = 120,
                    Gender = "Unisex",

                    Locations = new int[] { 1 },
                    Colors = new int[] { 1, 2 },
                    Sizes = new int[] { 1, 2 },
                    Pictures = new string[] { "image1", "image2" },
                    Quantity = 22,
                    Id = guid,
                    Description = "Product",
                };

                await service.CreateAsync(product);
                list[i].ProductCategories.Add(new ProductCategory { Category = new Category() { Id = 1 } });
            }

            for (int i = 4; i <= 6; i++)
            {
                var productWithRightCategories = new ProductViewModel()
                {
                    Name = $"Big Shirt {i}",
                    Price = 120,
                    Gender = "Unisex",

                    Locations = new int[] { 1 },
                    Colors = new int[] { 1, 2 },
                    Sizes = new int[] { 1, 2 },
                    Pictures = new string[] { "image1", "image2" },
                    Quantity = 22,
                    Id = guid,
                    Description = "Product",
                };

                await service.CreateAsync(productWithRightCategories);
                list[i].ProductCategories.Add(new ProductCategory { Category = new Category() { Id = 4 } });
            }

            var filtered = service.FilterByCategoryId(4);
            Assert.True(filtered.Count() == 3);
            foreach (var prod in filtered)
            {
                Assert.Contains(prod.Categories, x => x.Id == 4);
            }
        }

        [Fact]
        public async Task ProductFilterByGenderSholdFilter()
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
            for (int i = 0; i <= 3; i++)
            {
                var product = new ProductViewModel()
                {
                    Name = $"Big Shirt {i}",
                    Price = 120,
                    Gender = "Unisex",
                    Locations = new int[] { 1 },
                    Colors = new int[] { 1, 2 },
                    Sizes = new int[] { 1, 2 },
                    Pictures = new string[] { "image1", "image2" },
                    Quantity = 22,
                    Id = guid,
                    Description = "Product",
                };
                await service.CreateAsync(product);
            }

            for (int i = 4; i <= 6; i++)
            {
                var productWithRightCategories = new ProductViewModel()
                {
                    Name = $"Big Shirt {i}",
                    Price = 120,
                    Gender = "Male",
                    Locations = new int[] { 1 },
                    Colors = new int[] { 1, 2 },
                    Sizes = new int[] { 1, 2 },
                    Pictures = new string[] { "image1", "image2" },
                    Quantity = 22,
                    Id = guid,
                    Description = "Product",
                };
                await service.CreateAsync(productWithRightCategories);
            }

            var filtered = service.FilterByGenderId("Male");
            Assert.True(filtered.Count() == 3);
            foreach (var prod in filtered)
            {
                Assert.True(prod.Gender == "Male");
            }
        }

        [Fact]
        public async Task ProductFilterBySizeSholdFilter()
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
            for (int i = 0; i <= 3; i++)
            {
                var product = new ProductViewModel()
                {
                    Name = $"Big Shirt {i}",
                    Price = 120,
                    Gender = "Unisex",
                    Categories = new int[] { 1 },
                    Locations = new int[] { 1 },
                    Colors = new int[] { 1, 2 },
                    Pictures = new string[] { "image1", "image2" },
                    Quantity = 22,
                    Id = guid,
                    Description = "Product",
                };
                await service.CreateAsync(product);
                list[i].ProductSizes.Add(new ProductSize { Size = new Size() { Id = 1 } });
            }

            for (int i = 4; i <= 6; i++)
            {
                var productWithRightCategories = new ProductViewModel()
                {
                    Name = $"Big Shirt {i}",
                    Price = 120,
                    Gender = "Unisex",
                    Categories = new int[] { 1 },
                    Locations = new int[] { 1 },
                    Colors = new int[] { 1, 2 },
                    Pictures = new string[] { "image1", "image2" },
                    Quantity = 22,
                    Id = guid,
                    Description = "Product",
                };
                await service.CreateAsync(productWithRightCategories);
                list[i].ProductSizes.Add(new ProductSize { Size = new Size() { Id = 4 } });
            }

            var filtered = service.FilterBySizeId(4);
            Assert.True(filtered.Count() == 3);
            foreach (var prod in filtered)
            {
                Assert.Contains(prod.Sizes, x => x.Id == 4);
            }
        }

        [Fact]
        public async Task ProductFilterByColorSholdFilter()
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
            for (int i = 0; i <= 3; i++)
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
                    Id = guid,
                    Description = "Product",
                };
                await service.CreateAsync(product);
                list[i].ProductColors.Add(new ProductColor { Color = new Color() { Id = 1 } });
            }

            for (int i = 4; i <= 6; i++)
            {
                var productWithRightCategories = new ProductViewModel()
                {
                    Name = $"Big Shirt {i}",
                    Price = 120,
                    Gender = "Unisex",
                    Locations = new int[] { 1 },
                    Sizes = new int[] { 1, 2 },
                    Pictures = new string[] { "image1", "image2" },
                    Quantity = 22,
                    Id = guid,
                    Description = "Product",
                };
                await service.CreateAsync(productWithRightCategories);
                list[i].ProductColors.Add(new ProductColor { Color = new Color() { Id = 4 } });
            }

            var filtered = service.FilterByColorId(4);
            Assert.True(filtered.Count() == 3);
            foreach (var prod in filtered)
            {
                Assert.Contains(prod.Colors, x => x.Id == 4);
            }
        }
    }
}
