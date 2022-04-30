namespace SiteX.Data.Models.Shop
{
    using SiteX.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class Gender : BaseModel<int>
    {
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
    }
}
