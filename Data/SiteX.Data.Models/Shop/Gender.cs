namespace SiteX.Data.Models.Shop
{
    using System.ComponentModel.DataAnnotations;

    using SiteX.Data.Common.Models;

    public class Gender : BaseModel<int>
    {
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
    }
}
