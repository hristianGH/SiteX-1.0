namespace SiteX.Services.Data.ShopService.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductCategoryService
    {
        public Task CreatingProductCategoryAsync(ICollection<int> categories, Guid product);

        public Task HardDeleteProductCategoriesByIdAsync(Guid productId);
    }
}
