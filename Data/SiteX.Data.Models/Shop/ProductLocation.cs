namespace SiteX.Data.Models.Shop
{
    using System;
    using SiteX.Data.Common.Models;

    public class ProductLocation : BaseDeletableModel<int>
    {
        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }
    }
}
