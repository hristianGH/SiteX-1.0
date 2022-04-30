namespace SiteX.Services.Data.ShopService.Interface
{
    using SiteX.Data.Models.Shop;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IColorService
    {
        public IEnumerable<Color> GetColors();

        public Color GetColorById(int id);

        public Task EditColorAsync(Color color);

        public int GetColorsCount();

        public Task CreateAsync(Color viewModel);
    }
}
