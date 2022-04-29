namespace SiteX.Web.ViewModels.ShopViewModels.CategoryModels
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryViewModel
    {
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
