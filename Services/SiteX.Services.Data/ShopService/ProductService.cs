namespace SiteX.Services.Data.ShopService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService.Interface;
    using SiteX.Services.Mapping;
    using SiteX.Web.ViewModels.ShopViewModels.ProductModels;

    public class ProductService : IProductService
    {
        private readonly IDeletableEntityRepository<Product> productRepo;

        public ProductService(IDeletableEntityRepository<Product> productRepo
            )
        {
            this.productRepo = productRepo;
        }

        public async Task CreateAsync(ProductViewModel viewModel)
        {
            var product = new Product()
            {
                Name = viewModel.Name,
                User = viewModel.User,
                Description = viewModel.Description,
                Gender = viewModel.Gender,
                Price = viewModel.Price,
                Quantity = viewModel.Quantity,
            };
           await CreateProductPeriphery(viewModel, product);
            await this.productRepo.AddAsync(product);
            await this.productRepo.SaveChangesAsync();
        }

        public ICollection<Product> ReturnAll()
        {
            var products = this.productRepo.AllAsNoTracking().OrderByDescending(x => x.CreatedOn).ToList();

            return products;
        }

        public async Task RemoveProductAsync(Product product)
        {
            product.IsAvalable = false;
            this.productRepo.Delete(product);
            await this.productRepo.SaveChangesAsync();
        }

        public async Task SoftDeleteProductByIdAsync(Guid id)
        {
            var product = this.productRepo.All().Where(x => x.Id == id).FirstOrDefault();
            if (product != null)
            {
                await this.RemoveProductAsync(product);
            }
        }

        public ICollection<ProductOutputViewModel> ToPage(int page = 1, int itemsPerPage = 6)
        {
            var output = this.GetAllProductsAsOutModel().Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToList();
            return output;
        }

        public ICollection<ProductOutputViewModel> GetAllProductsAsOutModel()
        {
            var output = this.productRepo.AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .To<ProductOutputViewModel>()
                .ToList();

            return output;
        }

        public int GetProductCount()
        {
            return this.productRepo.AllAsNoTracking().Count();
        }

        public Product GetProductById(Guid id)
        {
            var product = this.productRepo.AllAsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            return product;
        }

        public ProductOutputViewModel GetOutputProductById(Guid id)
        {
            var result = this.productRepo.AllAsNoTracking().To<ProductOutputViewModel>().FirstOrDefault(x => x.Id == id);
            return result;
        }

        public ICollection<ProductOutputViewModel> FilterByCategoryId(int id)
        {
            var products = this.GetAllProductsAsOutModel().Where(x => x.Categories.Any(x => x.Id == id)).ToList();
            return products;
        }

        public ICollection<ProductOutputViewModel> FilterByGenderId(string gender)
        {
            var products = this.GetAllProductsAsOutModel().Where(x => x.Gender == gender).ToList();
            return products;
        }

        public ICollection<ProductOutputViewModel> FilterBySizeId(int id)
        {
            var products = this.GetAllProductsAsOutModel().Where(x => x.Sizes.Any(x => x.Id == id)).ToList();
            return products;
        }

        public ICollection<ProductOutputViewModel> FilterByColorId(int id)
        {
            var products = this.GetAllProductsAsOutModel().Where(x => x.Colors.Any(x => x.Id == id)).ToList();
            return products;
        }

        public async Task EditProductAsync(ProductViewModel viewModel)
        {
            var product = this.productRepo.All().Where(x => x.Id == viewModel.Id)
                .Include(x => x.ProductCategories)
                .Include(x => x.ProductColors)
                .Include(x => x.ProductImages)
                .Include(x => x.ProductLocations)
                .Include(x => x.ProductSizes).FirstOrDefault();
            product.Name = viewModel.Name;
            product.Description=viewModel.Description;
            product.Price=viewModel.Price;
            product.Gender = viewModel.Gender;
            product.Quantity=viewModel.Quantity;

            await this.DeleteProductPeriphery(product);
            await this.CreateProductPeriphery(viewModel, product);

            await this.productRepo.SaveChangesAsync();
        }

        public ProductViewModel GetProductEditById(Guid id)
        {
            var edit = this.productRepo.AllAsNoTracking().To<ProductViewModel>().Where(x => x.Id == id).FirstOrDefault();

            return edit;
        }

        public async Task BuyProductAsync(Product product)
        {
            var prod = this.productRepo.All().FirstOrDefault(x => x.Id == product.Id);
            if (prod.Quantity <= 1)
            {
                prod.IsAvalable = false;
                this.productRepo.Delete(prod);
            }

            Receit receit = new Receit()
            {
                Product = product,
                Price = product.Price,
                ProductId = product.Id,
                User = product.User,
                UserId = product.UserId,
                ProductName = product.Name,
            };
            //await this.receitService.CreateAsync(receit);
            //await this.productRepo.SaveChangesAsync();
        }

        public async Task CreateProductPeriphery(ProductViewModel viewModel, Product product)
        {
            foreach (var category in viewModel.Categories)
            {
                product.ProductCategories.Add(new ProductCategory() { ProductId = product.Id, CategoryId = category });
            }

            foreach (var image in viewModel.Pictures.Where(x => x != null))
            {
                product.ProductImages.Add(new ProductImage() { ProductId = product.Id, Path = image });
            }

            foreach (var location in viewModel.Locations)
            {
                product.ProductLocations.Add(new ProductLocation() { ProductId = product.Id, LocationId = location });
            }

            foreach (var color in viewModel.Colors)
            {
                product.ProductColors.Add(new ProductColor() { ProductId = product.Id, ColorId = color });
            }

            foreach (var size in viewModel.Sizes)
            {
                product.ProductSizes.Add(new ProductSize() { ProductId = product.Id, SizeId = size });
            }
        }

        public async Task DeleteProductPeriphery(Product product)
        {
            product.ProductCategories.Clear();
            product.ProductImages.Clear();
            product.ProductLocations.Clear();
            product.ProductColors.Clear();
            product.ProductSizes.Clear();
        }
    }
}
