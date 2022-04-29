namespace SiteX.Services.Data.ArticleService
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Article;
    using SiteX.Services.Data.ArticleService.Interface;

    public class ArticleService : IArticleService
    {
        private readonly IDeletableEntityRepository<Article> arcticleRepo;

        public ArticleService(IDeletableEntityRepository<Article> arcticleRepo)
        {
            this.arcticleRepo = arcticleRepo;
        }

        public async Task CreateArticleAsync(Article article)
        {
            if (article != null)
            {
                await this.arcticleRepo.AddAsync(article);
                await this.arcticleRepo.SaveChangesAsync();
            }
        }

        public async Task DeleteArticleAsync(Article article)
        {
            this.arcticleRepo.Delete(article);
            await this.arcticleRepo.SaveChangesAsync();
        }

        public IEnumerable<Article> GetArticles()
        {
            return this.arcticleRepo.AllAsNoTracking().ToList();
        }

        public ICollection<Article> ToPage(int page = 1, int itemsPerPage = 6)
        {
            var output = this.arcticleRepo.AllAsNoTracking().Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToList();
            return output;
        }

        public int GetArticlesCount()
        {
            return this.arcticleRepo.AllAsNoTracking().Count();
        }

        public Article GetArticleById(int id)
        {
            return this.arcticleRepo.AllAsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public async Task EditArticleAsync(Article article)
        {
            var edit = this.arcticleRepo.All().FirstOrDefault(x => x.Id == article.Id);
            edit.Title = article.Title;
            edit.Abstract = article.Abstract;
            edit.IdLink = article.IdLink;
            edit.Url = article.Url;

            await this.arcticleRepo.SaveChangesAsync();
        }
    }
}
