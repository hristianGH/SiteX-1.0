namespace SiteX.Data.Models.Shop
{
    using SiteX.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class Location : BaseModel<int>
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
