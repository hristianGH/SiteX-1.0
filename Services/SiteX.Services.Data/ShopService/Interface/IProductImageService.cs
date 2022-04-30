namespace SiteX.Services.Data.ShopService.Interface
{
    using SiteX.Data.Models.Shop;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductImageService
    {
        public ICollection<ProductImage> GetImagesByProductId(Guid id);

        public Task HardDeleteProductImagesByIdAsync(Guid productId);

        public Task CreatingProductImageAsync(ICollection<string> paths, Guid product);
    }
}
