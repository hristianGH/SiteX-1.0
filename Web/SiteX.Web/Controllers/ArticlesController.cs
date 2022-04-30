namespace SiteX.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SiteX.Services.Data.ArticleService.Interface;
    using SiteX.Web.ViewModels.ArticleViewModels;

    public class ArticlesController : Controller
    {
        private readonly IArticleService articleService;

        public ArticlesController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }

        public IActionResult All(int page = 1)
        {
            AllArticleViewModel articleViewModel = new AllArticleViewModel() { Articles = this.articleService.ToPage(page, 20), PageNumber = page, ItemsPerPage = 20 };

            articleViewModel.ItemsCount = this.articleService.GetArticlesCount();

            return this.View(articleViewModel);
        }

        public IActionResult ById(int id)
        {
            var article = this.articleService.GetArticleById(id);
            return this.View(article);
        }
    }
}
