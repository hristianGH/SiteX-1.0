namespace SiteX.Data.Models.Blog
{
    using SiteX.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PostImage : BaseDeletableModel<Guid>
    {
        [Required]
        public string Path { get; set; }

        public Post Post { get; set; }

        public int PostId { get; set; }
    }
}
