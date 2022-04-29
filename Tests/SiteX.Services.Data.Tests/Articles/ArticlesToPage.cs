using Moq;
using SiteX.Data.Common.Repositories;
using SiteX.Services.Data.ArticleService;
using SiteX.Data.Models.Article;
using SiteX.Data.Models.Team;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System;

namespace SiteX.Services.Data.Tests.Articles
{
    public class ArticlesToPage
    {
        [Fact]
        public async Task ArticlesToPageShouldReturnArticlesInToPageFormat()
        {
            var list = new List<Article>();

            var articleRepo = new Mock<IDeletableEntityRepository<Article>>();

            articleRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());

            articleRepo.Setup(x => x.AddAsync(It.IsAny<Article>())).Callback((Article x) => list.Add(x));
            articleRepo.Setup(x => x.Delete(It.IsAny<Article>())).Callback((Article x) => list.Remove(x));
            var service = new ArticleService.ArticleService(articleRepo.Object);

            for (int i = 0; i < 15; i++)
            {
                var article = new Article() { Title = "Title", Abstract = "Some Text", Id = i };

                await service.CreateArticleAsync(article);
                list[i].Id = i;
            }

            Assert.NotEmpty(list);

            for (int page = 1; page <= 20; page++)
            {
                var currentPage = service.ToPage(page, 6);
                if (Math.Ceiling((double)list.Count / 6) >= page)
                {
                    Assert.True(currentPage.Any());
                }
                else
                {
                    Assert.True(currentPage.Count == 0);
                }
            }
        }
    }
}
