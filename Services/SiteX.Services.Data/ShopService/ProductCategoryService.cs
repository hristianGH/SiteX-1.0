namespace SiteX.Services.Data.ShopService
{
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IDeletableEntityRepository<ProductCategory> productCategoryRepo;

        public ProductCategoryService(IDeletableEntityRepository<ProductCategory> productCategoryRepo)
        {
            this.productCategoryRepo = productCategoryRepo;
        }

        public async Task CreatingProductCategoryAsync(ICollection<int> categories, Guid product)
        {
            foreach (var item in categories)
            {
                var entity = new ProductCategory();
                entity.ProductId = product;
                entity.CategoryId = item;
                await this.productCategoryRepo.AddAsync(entity);
            }

            await this.productCategoryRepo.SaveChangesAsync();
        }

        public async Task HardDeleteProductCategoriesByIdAsync(Guid productId)
        {
            var categories = this.productCategoryRepo.All().Where(x => x.ProductId == productId).ToList();
            foreach (var category in categories)
            {
                this.productCategoryRepo.HardDelete(category);
            }

            await this.productCategoryRepo.SaveChangesAsync();
            categories = this.productCategoryRepo.All().Where(x => x.ProductId == productId).ToList();
        }
    }
}
