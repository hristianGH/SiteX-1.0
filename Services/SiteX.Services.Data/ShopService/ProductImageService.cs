namespace SiteX.Services.Data.ShopService
{
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductImageService : IProductImageService
    {
        private readonly IDeletableEntityRepository<ProductImage> prodImageRepo;

        public ProductImageService(IDeletableEntityRepository<ProductImage> imageRepo)
        {
            this.prodImageRepo = imageRepo;
        }

        public async Task CreatingProductImageAsync(ICollection<string> paths, Guid product)
        {
            foreach (var item in paths)
            {
                var entity = new ProductImage();
                entity.ProductId = product;
                entity.Path = item;
                await this.prodImageRepo.AddAsync(entity);
            }

            await this.prodImageRepo.SaveChangesAsync();
        }

        public async Task HardDeleteProductImagesByIdAsync(Guid productId)
        {
            var images = this.prodImageRepo.All().Where(x => x.ProductId == productId).ToList();
            foreach (var image in images)
            {
                this.prodImageRepo.HardDelete(image);
            }

            await this.prodImageRepo.SaveChangesAsync();
        }

        public ICollection<ProductImage> GetImagesByProductId(Guid id)
        {
            return this.prodImageRepo.AllAsNoTracking().Where(x => x.ProductId == id).ToList();
        }

    }
}
