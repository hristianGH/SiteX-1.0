namespace SiteX.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService.Interface;

    public class ColorsController : AdministrationController
    {
        private readonly IColorService colorService;

        public ColorsController(IColorService colorService)
        {
            this.colorService = colorService;
        }

        public IActionResult Index()
        {
            var colors = this.colorService.GetColors();
            return this.View(colors);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Color viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.colorService.CreateAsync(viewModel);
            return this.RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var viewModel = this.colorService.GetColorById(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Color viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.colorService.EditColorAsync(viewModel);

            return this.RedirectToAction("Index");
        }
    }
}
