namespace SiteX.Data.Models.Shop
{
    using SiteX.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Receit : BaseModel<Guid>
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        public Guid ProductId { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
