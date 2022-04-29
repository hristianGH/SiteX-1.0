namespace SiteX.Services.Data.ShopService.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SiteX.Data.Models.Shop;
    using SiteX.Web.ViewModels.ShopViewModels.ColorModels;

    public interface IColorService
    {
        public IEnumerable<Color> GetColors();

        public Color GetColorById(int id);

        public Task EditColorAsync(Color color);

        public int GetColorsCount();

        public Task CreateAsync(Color viewModel);
    }
}
