namespace SiteX.Services.Data.Tests.Articles
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Moq;
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Article;
    using Xunit;

    public class CreateArticle
    {
        [Fact]
        public async Task CreateArticleShouldAddArticleToRepository()
        {
            var list = new List<Article>();

            var mockProductRepo = new Mock<IDeletableEntityRepository<Article>>();

            mockProductRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());

            mockProductRepo.Setup(x => x.AddAsync(It.IsAny<Article>())).Callback((Article x) => list.Add(x));

            var service = new ArticleService.ArticleService(mockProductRepo.Object);

            var article = new Article() { Title = "Title", Abstract = "Some Text" };

            await service.CreateArticleAsync(article);

            Assert.NotEmpty(list);
            Assert.True(list.First().Title == "Title");
        }
    }
}
