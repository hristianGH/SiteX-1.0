namespace SiteX.Data.Models.Blog
{
    using SiteX.Data.Common.Models;

    public class PostGenre : BaseDeletableModel<int>
    {
        public Post Post { get; set; }

        public int PostId { get; set; }

        public Genre Genre { get; set; }

        public int GenreId { get; set; }
    }
}
