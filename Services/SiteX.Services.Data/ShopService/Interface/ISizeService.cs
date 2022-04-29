namespace SiteX.Services.Data.ShopService.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SiteX.Data.Models.Shop;
    using SiteX.Web.ViewModels.ShopViewModels.SizeModels;

    public interface ISizeService
    {
        public IEnumerable<Size> GetSizes();

        public Size GetSizeById(int id);

        public Task EditSizeAsync(Size model);

        // TODO Color view Model uses Name only like SIze so im gonna save some code
        public Task CreateAsync(SizeViewModel viewModel);
    }
}
