namespace SiteX.Services.Data.ShopService.Interface
{
    using SiteX.Data.Models.Shop;
    using SiteX.Web.ViewModels.ShopViewModels.LocationModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILocationService
    {
        public IEnumerable<Location> GetLocations();

        public Task EditAsync(Location location);

        public Task CreateAsync(LocationViewModel viewModel);

        public Location GetLocationById(int id);

        // ToDO MAKE I CATEGORY,IGENDER,ILOCATION,IPICTURES SERVICES ONE MAIN KEYVALUEPAIR SERVICE INTERFACE
    }
}
