﻿namespace SiteX.Web.ViewModels.BlogViewModels
{
    using SiteX.Data.Models;
    using SiteX.Data.Models.Blog;
    using System.ComponentModel.DataAnnotations;

    public class CommentViewModel
    {
        public Post Post { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required]
        [MaxLength(350)]
        [MinLength(3)]
        public string Body { get; set; }

        public ApplicationUser User { get; set; }

        public Comment Parent { get; set; }

        public int? ParentId { get; set; }
    }
}
