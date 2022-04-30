using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteX.Data.Models.Shop;
using SiteX.Services.Data.ShopService.Interface;
using SiteX.Web.ViewModels.ShopViewModels.SizeModels;
using System.Threading.Tasks;

namespace SiteX.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SizeController : ControllerBase
    {


        private readonly ISizeService sizeService;

        public SizeController(ISizeService sizeService)
        {
            this.sizeService = sizeService;
        }

        [HttpGet]
        [Route("All")]
        public IActionResult Index()
        {
            var sizes = this.sizeService.GetSizes();
            return this.Ok(sizes);
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(SizeViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.sizeService.CreateAsync(viewModel);
            return this.Ok(viewModel);
        }


        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(Size viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.sizeService.EditSizeAsync(viewModel);

            return this.Ok(viewModel);
        }
    }
}
