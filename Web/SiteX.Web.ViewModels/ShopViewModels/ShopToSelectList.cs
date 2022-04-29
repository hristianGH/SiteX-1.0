namespace SiteX.Web.ViewModels.ShopViewModels
{
    using System.Collections.Generic;

    using SiteX.Data.Models.Shop;

    public class ShopToSelectList
    {
        public IEnumerable<string> GendersToList { get; set; } = new List<string>();

        public IEnumerable<Category> CategoriesToList { get; set; } = new List<Category>();

        public IEnumerable<Location> LocationsToList { get; set; } = new List<Location>();

        public IEnumerable<Size> SizesToList { get; set; } = new List<Size>();

        public IEnumerable<Color> ColorsToList { get; set; } = new List<Color>();
    }
}
