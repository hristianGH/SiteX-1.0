namespace SiteX.Web.ViewModels.ShopViewModels.ProductModels
{
    using System.Collections.Generic;

    public class ProductAllViewModel : PagingViewModel
    {
        public ICollection<ProductOutputViewModel> Products { get; set; } = new List<ProductOutputViewModel>();

        public ShopToSelectList ToSelectList { get; set; }
    }
}
