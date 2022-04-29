namespace SiteX.Data.Models.Blog
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using SiteX.Data.Common.Models;

    public class PostImage : BaseDeletableModel<Guid>
    {
        [Required]
        public string Path { get; set; }

        public Post Post { get; set; }

        public int PostId { get; set; }
    }
}
