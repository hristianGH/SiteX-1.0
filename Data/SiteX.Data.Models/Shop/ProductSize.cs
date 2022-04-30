namespace SiteX.Data.Models.Shop
{
    using System;
    using SiteX.Data.Common.Models;

    public class ProductSize : BaseDeletableModel<int>
    {
        public Size Size { get; set; }

        public int SizeId { get; set; }

        public Product Product { get; set; }

        public Guid ProductId { get; set; }
    }
}
