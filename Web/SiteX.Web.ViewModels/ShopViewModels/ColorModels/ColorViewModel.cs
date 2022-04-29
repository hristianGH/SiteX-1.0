namespace SiteX.Web.ViewModels.ShopViewModels.ColorModels
{
    using System.ComponentModel.DataAnnotations;

    public class ColorViewModel
    {
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
