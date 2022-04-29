namespace SiteX.Services.Data.ShopService.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SiteX.Data.Models.Shop;

    public interface IProductLocationService
    {
        public Task CreatingProductLocationAsync(ICollection<int> locations, Guid product);

        public Task HardDeleteProductLocationByIdAsync(Guid productId);

    }
}
