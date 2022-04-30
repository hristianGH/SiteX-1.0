namespace SiteX.Web.ViewModels.ShopViewModels.ProductModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BuyingProductViewModel : ShopToSelectList
    {

        public ProductOutputViewModel Product { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string Size { get; set; }
    }
}
