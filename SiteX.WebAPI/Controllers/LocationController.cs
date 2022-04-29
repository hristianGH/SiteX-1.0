using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteX.Data.Models.Shop;
using SiteX.Services.Data.ShopService.Interface;
using SiteX.Web.ViewModels.ShopViewModels.LocationModels;
using System.Threading.Tasks;

namespace SiteX.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService locationService;

        public LocationController(ILocationService locationService)
        {
            this.locationService = locationService;
        }

        [HttpGet("All")]
        public IActionResult Index()
        {
            var locations = this.locationService.GetLocations();
            return this.Ok(locations);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(LocationViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.locationService.CreateAsync(viewModel);
            return this.Ok(viewModel);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(Location viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.locationService.EditAsync(viewModel);

            return this.Ok(viewModel);
        }

    }
}
