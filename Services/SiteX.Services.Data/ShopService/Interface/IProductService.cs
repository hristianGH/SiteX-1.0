namespace SiteX.Services.Data.ShopService.Interface
{
    using SiteX.Data.Models.Shop;
    using SiteX.Web.ViewModels.ShopViewModels.ProductModels;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductService
    {
        public Task CreateAsync(ProductViewModel viewModel);

        public ICollection<ProductOutputViewModel> ToPage(int page = 1, int itemsPerPage = 6);

        public ICollection<ProductOutputViewModel> GetAllProductsAsOutModel();

        public ICollection<ProductOutputViewModel> FilterByCategoryId(int id);

        public ICollection<ProductOutputViewModel> FilterByGenderId(string gender);

        public ICollection<ProductOutputViewModel> FilterBySizeId(int id);

        public ICollection<ProductOutputViewModel> FilterByColorId(int id);

        public Task RemoveProductAsync(Product product);

        public Task SoftDeleteProductByIdAsync(Guid id);

        public ICollection<Product> ReturnAll();

        public int GetProductCount();

        public Product GetProductById(Guid id);

        public ProductOutputViewModel GetOutputProductById(Guid id);

        public ProductViewModel GetProductEditById(Guid id);

        public Task EditProductAsync(ProductViewModel viewModel);

        public Task CreateProductPeriphery(ProductViewModel viewModel, Product product);

        public Task DeleteProductPeriphery(Product product);

        public Task BuyProductAsync(Product product);
    }
}
