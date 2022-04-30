namespace SiteX.Data.Models.Shop
{
    using SiteX.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ProductImage : BaseDeletableModel<int>
    {
        [Required]
        public string Path { get; set; }

        public Product Product { get; set; }

        public Guid ProductId { get; set; }
    }
}
