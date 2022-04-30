namespace SiteX.Services.Data.ArticleService.Interface
{
    using SiteX.Data.Models.Article;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArticleService
    {
        public Task CreateArticleAsync(Article article);

        public Task DeleteArticleAsync(Article article);

        public Article GetArticleById(int id);

        public IEnumerable<Article> GetArticles();

        public ICollection<Article> ToPage(int page = 1, int itemsPerPage = 6);

        public int GetArticlesCount();

        public Task EditArticleAsync(Article article);

    }
}
