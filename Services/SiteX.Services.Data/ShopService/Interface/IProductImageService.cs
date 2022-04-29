namespace SiteX.Services.Data.ShopService.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SiteX.Data.Models.Shop;

    public interface IProductImageService
    {
        public ICollection<ProductImage> GetImagesByProductId(Guid id);

        public Task HardDeleteProductImagesByIdAsync(Guid productId);

        public Task CreatingProductImageAsync(ICollection<string> paths, Guid product);
    }
}
