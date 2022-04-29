namespace SiteX.Services.Data.ShopService.Interface
{
    using SiteX.Web.ViewModels.ShopViewModels;
    using System.Threading.Tasks;

    public interface IProductListService
    {
        public Task<ShopToSelectList> ToSelectListAsync();
    }
}
