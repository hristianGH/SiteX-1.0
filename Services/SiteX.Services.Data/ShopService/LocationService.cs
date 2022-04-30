namespace SiteX.Services.Data.ShopService
{
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService.Interface;
    using SiteX.Web.ViewModels.ShopViewModels.LocationModels;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class LocationService : ILocationService
    {
        private readonly IRepository<Location> locationRepository;

        public LocationService(
            IRepository<Location> locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        public async Task CreateAsync(LocationViewModel viewModel)
        {
            var location = new Location() { Name = viewModel.Name, Address = viewModel.Address };
            await this.locationRepository.AddAsync(location);
            await this.locationRepository.SaveChangesAsync();
        }

        public IEnumerable<Location> GetLocations()
        {
            var locations = this.locationRepository.AllAsNoTracking().ToArray();
            return locations;
        }

        public Location GetLocationById(int id)
        {
            return this.locationRepository.All().Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task EditAsync(Location location)
        {
            var locationEdit = this.locationRepository.All().FirstOrDefault(x => x.Id == location.Id);
            locationEdit.Name = location.Name;
            locationEdit.Address = location.Address;
            await this.locationRepository.SaveChangesAsync();
        }
    }
}
