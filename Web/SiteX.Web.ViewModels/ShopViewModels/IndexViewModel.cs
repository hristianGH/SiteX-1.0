namespace SiteX.Web.ViewModels.ShopViewModels
{
    using SiteX.Data.Models.Shop;
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public ICollection<Category> Categories { get; set; } = new List<Category>();

        public ICollection<Location> Locations { get; set; } = new List<Location>();

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
