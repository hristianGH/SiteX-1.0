namespace SiteX.Services.Data.Tests.Articles
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Moq;
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Article;
    using Xunit;

    public class GetArticleById
    {
        [Fact]
        public async Task GetArticleByIdShouldReturnArticleById()
        {
            var list = new List<Article>();

            var mockProductRepo = new Mock<IDeletableEntityRepository<Article>>();

            mockProductRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());

            mockProductRepo.Setup(x => x.AddAsync(It.IsAny<Article>())).Callback((Article x) => list.Add(x));
            mockProductRepo.Setup(x => x.Delete(It.IsAny<Article>())).Callback((Article x) => list.Remove(x));
            var service = new ArticleService.ArticleService(mockProductRepo.Object);

            for (int i = 0; i < 3; i++)
            {
                var article = new Article() { Title = "Title", Abstract = "Some Text", Id = i };

                await service.CreateArticleAsync(article);
                list[i].Id = i;
            }

            Assert.NotEmpty(list);
            var articleById = service.GetArticleById(1);

            Assert.NotNull(articleById);
            Assert.True(articleById.Id == 1);
            Assert.True(articleById.Title == "Title");
            Assert.True(articleById.Abstract == "Some Text");
        }
    }
}
