namespace SiteX.Data.Models.Shop
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using SiteX.Data.Common.Models;

    public class Category : BaseModel<int>
    {
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }
}
