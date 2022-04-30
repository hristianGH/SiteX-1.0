namespace SiteX.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AngleSharp;
    using SiteX.Data.Models.Article;

    public class ArticleSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Articles.Count() < 100)
            {
                var configuration = Configuration.Default.WithDefaultLoader();
                var context = BrowsingContext.New(configuration);
                var articles = new List<Article>();
                Parallel.For(35_438_900, 35_439_200, (i) =>
                {
                    var article = GetArticle(context, i);
                    if (article != null)
                    {
                        articles.Add(article);
                    }
                });
                await dbContext.AddRangeAsync(articles);
            }
        }

        public static Article GetArticle(IBrowsingContext context, int id)
        {
            var article = new Article();
            var document = context.OpenAsync($"https://pubmed.ncbi.nlm.nih.gov/{id}/").GetAwaiter().GetResult();

            var name = document.QuerySelector(".heading-title");
            var desc = document.QuerySelector(".abstract-content");
            var idlink = document.QuerySelector(".id-link");

            var currLink = document.BaseUrl;

            if (name != null && desc != null && idlink != null)
            {
                article.Title = name.TextContent;
                article.Abstract = desc.TextContent;
                article.IdLink = idlink.TextContent;
                article.Url = currLink.Href;
                return article;
            }

            return null;
        }
    }
}
