using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiteX.Data.Models;
using SiteX.Services.Data.ShopService.Interface;
using SiteX.Web.ViewModels.ShopViewModels.ProductModels;
using System;
using System.Threading.Tasks;


namespace SiteX.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenderService genderService;
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        private readonly ILocationService locationService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ISizeService sizeService;
        private readonly IColorService colorService;

        public ProductController(
            IGenderService genderService,
            ICategoryService categoryService,
            IProductService productService,
            ILocationService locationService,
            UserManager<ApplicationUser> userManager,
            ISizeService sizeService,
            IColorService colorService)
        {
            this.genderService = genderService;
            this.categoryService = categoryService;
            this.productService = productService;
            this.locationService = locationService;
            this.userManager = userManager;
            this.sizeService = sizeService;
            this.colorService = colorService;
        }

        [HttpGet]
        [Route("All")]
        public IActionResult All()
        {
            var products = this.productService.ReturnAll();
            return this.Ok(products);
        }

        [HttpGet("ById{id}")]
        public IActionResult Byid(Guid id)
        {
            var product = this.productService.GetProductById(id);
            if (product != null)
            {
                return this.Ok(product);
            }
            return this.NotFound();
        }



        [HttpPost("Create")]
        public async Task<IActionResult> Create(ProductViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            viewModel.User = await this.userManager.GetUserAsync(this.User);

            await this.productService.CreateAsync(viewModel);
            return this.Redirect("/");
        }



        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(ProductViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.productService.EditProductAsync(viewModel);

            return this.Redirect("/");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(BuyingProductViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.productService.SoftDeleteProductByIdAsync(model.ProductId);

            return this.Ok();
        }
    }
}
