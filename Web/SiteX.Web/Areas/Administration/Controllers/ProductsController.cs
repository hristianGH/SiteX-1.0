namespace SiteX.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SiteX.Data.Models;
    using SiteX.Services.Data.ShopService.Interface;
    using SiteX.Web.ViewModels.ShopViewModels.ProductModels;

    public class ProductsController : AdministrationController
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProductImageService productImageService;
        private readonly IProductListService toListService;

        public ProductsController(
            ICategoryService categoryService,
            IProductService productService,
            UserManager<ApplicationUser> userManager,
            IProductImageService productImageService,
            IProductListService toListService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
            this.userManager = userManager;
            this.productImageService = productImageService;
            this.toListService = toListService;
        }

        public async Task<IActionResult> Index()
        {
            var products = this.productService.ReturnAll();
            return this.View(products);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new ProductViewModel();
            var toList = await this.toListService.ToSelectListAsync();
            viewModel.GendersToList = toList.GendersToList;
            viewModel.CategoriesToList = toList.CategoriesToList;
            viewModel.LocationsToList = toList.LocationsToList;
            viewModel.SizesToList = toList.SizesToList;
            viewModel.ColorsToList = toList.ColorsToList;
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            viewModel.User = await this.userManager.GetUserAsync(this.User);

            await this.productService.CreateAsync(viewModel);
            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var viewModel = this.productService.GetProductEditById(id);

            if (viewModel.Pictures.Count() == 0)
            {
                viewModel.Pictures.Add(string.Empty);
            }

            var toList = await this.toListService.ToSelectListAsync();
            viewModel.GendersToList = toList.GendersToList;
            viewModel.CategoriesToList = toList.CategoriesToList;
            viewModel.LocationsToList = toList.LocationsToList;
            viewModel.SizesToList = toList.SizesToList;
            viewModel.ColorsToList = toList.ColorsToList;

            this.ViewBag.CategoriesCount = this.categoryService.GetCategoryCount();
            this.ViewBag.ProductId = viewModel.Id;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.productService.EditProductAsync(viewModel);

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var product = this.productService.GetOutputProductById(id);
            this.ViewBag.ImageOne = this.productImageService.GetImagesByProductId(id).Select(x => x.Path).FirstOrDefault();
            this.ViewBag.Images = this.productImageService.GetImagesByProductId(id).Select(x => x.Path).Skip(1);
            var viewmodel = new BuyingProductViewModel() { ProductId = product.Id, Product = product };

            viewmodel.CategoriesToList = product.Categories;
            viewmodel.LocationsToList = product.Locations;
            viewmodel.SizesToList = product.Sizes;
            viewmodel.ColorsToList = product.Colors;
            return this.View(viewmodel);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(BuyingProductViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.productService.SoftDeleteProductByIdAsync(model.ProductId);

            return this.RedirectToAction("Index");
        }
    }
}
