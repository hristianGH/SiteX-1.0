using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteX.Data.Models.Article;
using SiteX.Services.Data.ArticleService.Interface;
using System.Threading.Tasks;

namespace SiteX.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService articleService;

        public ArticleController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        // GET: ArticlesController
        [HttpGet("All")]
        public async Task<IActionResult> All()
        {
            var articles = this.articleService.GetArticles();
            if (articles != null)
            {

                return this.Ok(articles);
            }
            else
            {
                return this.NotFound();
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(Article article)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.articleService.CreateArticleAsync(article);
            return Ok(article);
        }
 

        // POST: ArticlesController/Edit/5
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(Article edit)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }
            this.articleService.EditArticleAsync(edit);
            return Ok(edit);
        }

        // POST: ArticlesController/Delete/5
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await articleService.DeleteArticleAsync(article);
            return Ok(article);
        }
    }
}
