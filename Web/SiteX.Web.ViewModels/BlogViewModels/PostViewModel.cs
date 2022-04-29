namespace SiteX.Web.ViewModels.BlogViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using SiteX.Data.Models;
    using SiteX.Data.Models.Blog;
    using SiteX.Services.Mapping;

    public class PostViewModel: IMapFrom<Post>
    {
        [Required]
        [MaxLength(150)]
        [MinLength(10)]
        public string Title { get; set; }

        [Required]
        [MaxLength(10_000)]
        [MinLength(10)]
        public string Body { get; set; }

        public ApplicationUser User { get; set; }

        [MinLength(1)]
        [Display(Name = "Picture Url")]
        public virtual ICollection<string> PostImages { get; set; } = new List<string>();

        [Display(Name = "Genres")]
        [MaxLength(2)]
        public ICollection<int> PostGenres { get; set; } = new List<int>();
    }
}
