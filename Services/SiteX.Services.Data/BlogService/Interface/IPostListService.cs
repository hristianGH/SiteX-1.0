namespace SiteX.Services.Data.BlogService.Interface
{
    using SiteX.Web.ViewModels.BlogViewModels;

    public interface IPostListService
    {
        public BlogToSelectedList ToSelectedList();
    }
}
