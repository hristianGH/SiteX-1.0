namespace SiteX.Services.Data.ShopService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService.Interface;

    public class ProductLocationService : IProductLocationService
    {
        private readonly IDeletableEntityRepository<ProductLocation> productLocationRepo;

        public ProductLocationService(IDeletableEntityRepository<ProductLocation> productLocationRepo)
        {
            this.productLocationRepo = productLocationRepo;
        }

        public async Task CreatingProductLocationAsync(ICollection<int> locations, Guid product)
        {
            foreach (var item in locations)
            {
                var entity = new ProductLocation();
                entity.ProductId = product;
                entity.LocationId = item;
                await this.productLocationRepo.AddAsync(entity);
            }

            await this.productLocationRepo.SaveChangesAsync();
        }

        public async Task HardDeleteProductLocationByIdAsync(Guid productId)
        {
            var locations = this.productLocationRepo.All().Where(x => x.ProductId == productId).ToList();
            foreach (var location in locations)
            {
                this.productLocationRepo.HardDelete(location);
            }

            await this.productLocationRepo.SaveChangesAsync();
        }

    }
}
