namespace SiteX.Web.ViewModels.BlogViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using SiteX.Data.Models.Blog;

    public class BlogToSelectedList
    {
        public IEnumerable<Genre> GenresToList { get; set; } = new List<Genre>();
    }
}
