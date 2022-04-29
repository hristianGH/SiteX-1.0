namespace SiteX.Services.Data.ShopService.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using SiteX.Data.Models.Shop;

    public interface IReceitService
    {
        public Task CreateAsync(Receit receit);

        public Receit GetById(Guid id);

    }
}
