namespace SiteX.Data.Models.Shop
{
    using SiteX.Data.Common.Models;
    using System;

    public class ProductCategory : BaseDeletableModel<int>
    {
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }
    }
}
