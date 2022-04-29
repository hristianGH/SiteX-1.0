namespace SiteX.Services.Data.ShopService.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductSizeService
    {
        public Task CreatingProductSizeAsync(ICollection<int> sizes, Guid product);

        public Task HardDeleteProductSizeByIdAsync(Guid id);
    }
}
