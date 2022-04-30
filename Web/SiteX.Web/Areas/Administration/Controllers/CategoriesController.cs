namespace SiteX.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService.Interface;

    public class CategoriesController : AdministrationController
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = this.categoryService.GetCategories();
            return this.View(categories);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.categoryService.CreateAsync(viewModel);
            return this.RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var viewModel = this.categoryService.GetCategoryById(id);
            return this.View(viewModel);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Edit(Category viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.categoryService.EditCategoryAsync(viewModel);

            return this.RedirectToAction("Index");
        }
    }
}
