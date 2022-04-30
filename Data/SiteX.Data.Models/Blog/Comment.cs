namespace SiteX.Data.Models.Blog
{
    using SiteX.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment : BaseDeletableModel<int>
    {
        [MaxLength(250)]
        [MinLength(1)]
        [Required]
        public string Body { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public int? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public virtual Comment Parent { get; set; }

        public Post Post { get; set; }

        public int PostId { get; set; }
    }
}
