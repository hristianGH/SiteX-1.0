namespace SiteX.Data.Models.Blog
{
    using System.ComponentModel.DataAnnotations;

    using SiteX.Data.Common.Models;

    public class Genre : BaseModel<int>
    {
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
