namespace SiteX.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService.Interface;
    using SiteX.Web.ViewModels.ShopViewModels.LocationModels;

    public class LocationsController : AdministrationController
    {
        private readonly ILocationService locationService;

        public LocationsController(ILocationService locationService)
        {
            this.locationService = locationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var locations = this.locationService.GetLocations();
            return this.View(locations);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(LocationViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.locationService.CreateAsync(viewModel);
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Edit")]
        public IActionResult Edit(int id)
        {
            var viewModel = this.locationService.GetLocationById(id);

            return this.View(viewModel);
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(Location viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.locationService.EditAsync(viewModel);

            return this.RedirectToAction("Index");
        }
    }
}
