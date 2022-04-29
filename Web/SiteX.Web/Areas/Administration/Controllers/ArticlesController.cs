using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteX.Data.Models.Article;
using SiteX.Services.Data.ArticleService.Interface;
using System.Threading.Tasks;

namespace SiteX.Web.Areas.Administration.Controllers
{
    public class ArticlesController : AdministrationController
    {
        private readonly IArticleService articleService;

        public ArticlesController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        // GET: ArticlesController
        public IActionResult Index()
        {
            var articles = this.articleService.GetArticles();
            if (articles != null)
            {

                return this.View(articles);
            }
            else
            {
                return this.NotFound();
            }
        }

        // GET: ArticlesController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        // GET: ArticlesController/Create
        public async Task<IActionResult> Create()
        {
            var article = new Article();
            return View(article);
        }

        // POST: ArticlesController/Create
        [HttpPost]
        public async Task<IActionResult> Create(Article article)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.articleService.CreateArticleAsync(article);
            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: ArticlesController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var edit = new Article();
            try
            {
                edit = this.articleService.GetArticleById(id);

            }
            catch (System.Exception)
            {
                return this.NotFound(id);
            }
            return this.View(edit);
        }

        // POST: ArticlesController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Article edit)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }
           await this.articleService.EditArticleAsync(edit);
            return RedirectToAction(nameof(Index));
        }

        // GET: ArticlesController/Delete/5
        public ActionResult Delete(int id)
        {
            var article = this.articleService.GetArticleById(id);
            return View(article);
        }

        // POST: ArticlesController/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await articleService.DeleteArticleAsync(article);
            return RedirectToAction(nameof(Index));
        }
    }
}
