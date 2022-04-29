namespace SiteX.Services.Data.ShopService.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductColorService
    {
        public Task CreatingProductColorAsync(ICollection<int> colors, Guid product);

        public Task HardDeleteProductColorByIdAsync(Guid id);
    }
}
