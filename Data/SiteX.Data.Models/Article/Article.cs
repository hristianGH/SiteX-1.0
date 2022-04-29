namespace SiteX.Data.Models.Article
{
    using SiteX.Data.Common.Models;

    public class Article : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string Abstract { get; set; }

        public string Url { get; set; }

        public string IdLink { get; set; }

    }
}
