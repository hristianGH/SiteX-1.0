namespace SiteX.Web.ViewModels.BlogViewModels
{
    using SiteX.Data.Models.Blog;
    using System.Collections.Generic;

    public class BlogToSelectedList
    {
        public IEnumerable<Genre> GenresToList { get; set; } = new List<Genre>();
    }
}
