namespace SiteX.Data.Models.Shop
{
    using SiteX.Data.Common.Models;
    using System;

    public class ProductColor : BaseDeletableModel<int>
    {
        public Color Color { get; set; }

        public int ColorId { get; set; }

        public Product Product { get; set; }

        public Guid ProductId { get; set; }
    }
}
