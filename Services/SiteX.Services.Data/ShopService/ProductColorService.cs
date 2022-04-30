namespace SiteX.Services.Data.ShopService
{
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductColorService : IProductColorService
    {
        private readonly IDeletableEntityRepository<ProductColor> prodColorRepo;

        public ProductColorService(IDeletableEntityRepository<ProductColor> prodColorRepo)
        {
            this.prodColorRepo = prodColorRepo;
        }

        public async Task CreatingProductColorAsync(ICollection<int> colors, Guid product)
        {
            foreach (var item in colors)
            {
                var entity = new ProductColor();
                entity.ProductId = product;
                entity.ColorId = item;

                await this.prodColorRepo.AddAsync(entity);
            }

            await this.prodColorRepo.SaveChangesAsync();
        }

        public async Task HardDeleteProductColorByIdAsync(Guid id)
        {
            var colors = this.prodColorRepo.All().Where(x => x.ProductId == id).ToList();
            foreach (var color in colors)
            {
                this.prodColorRepo.HardDelete(color);
            }

            await this.prodColorRepo.SaveChangesAsync();
        }
    }
}
