namespace SiteX.Web.ViewModels.ShopViewModels.LocationModels
{
    using System.ComponentModel.DataAnnotations;

    public class LocationViewModel
    {
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(10)]
        public string Address { get; set; }
    }
}
