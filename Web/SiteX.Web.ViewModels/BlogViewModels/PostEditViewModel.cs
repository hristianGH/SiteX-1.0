namespace SiteX.Web.ViewModels.BlogViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using SiteX.Data.Models;

    public class PostEditViewModel : BlogToSelectedList
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        [MinLength(10)]
        public string Title { get; set; }

        [Required]
        [MaxLength(10_000)]
        [MinLength(10)]
        public string Body { get; set; }

        [MinLength(1)]
        [Display(Name = "Tumbnail picure Url")]
        public virtual ICollection<string> PostImages { get; set; } = new List<string>();

        [Display(Name = "Genres")]
        [MaxLength(2)]
        public ICollection<int> PostGenres { get; set; } = new List<int>();
    }
}
