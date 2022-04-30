namespace SiteX.Data.Models.Blog
{
    using SiteX.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class Genre : BaseModel<int>
    {
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
