namespace SiteX.Data.Models.Blog
{
    using SiteX.Data.Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Post : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(100)]
        [MinLength(10)]
        public string Title { get; set; }

        [Required]
        [MaxLength(10_000)]
        [MinLength(10)]
        public string Body { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [MaxLength(4)]
        public virtual ICollection<PostImage> PostImages { get; set; } = new List<PostImage>();

        public ICollection<PostGenre> PostGenres { get; set; } = new List<PostGenre>();
    }
}
