namespace SiteX.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using SiteX.Data.Models.Blog;
    using SiteX.Services.Data.BlogService.Interface;
    using SiteX.Web.ViewModels.BlogViewModels;

    public class GenresController : AdministrationController
    {
        private readonly IGenreService genreService;

        public GenresController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        // GET: GenreController
        public ActionResult Index()
        {
            var genres = this.genreService.GetGenres();
            return this.View(genres);
        }

        // GET: GenreController/Details/5
        public ActionResult Details(int id)
        {
            return this.View();
        }

        // GET: GenreController/Create
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GenreViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.genreService.CreateAsync(viewModel);
            return this.RedirectToAction("Index");

        }

        // GET: GenreController/Edit/5
        public ActionResult Edit(int id)
        {
            var viewModel = this.genreService.GetGenreById(id);

            return this.View(viewModel);
        }

        // POST: GenreController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Genre genre)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.genreService.EditAsync(genre);

            return this.RedirectToAction("Index");

        }

        // GET: GenreController/Delete/5
        public ActionResult Delete(int id)
        {
            return this.View();
        }

        // POST: GenreController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return this.RedirectToAction(nameof(this.Index));
            }
            catch
            {
                return this.View();
            }
        }
    }
}
