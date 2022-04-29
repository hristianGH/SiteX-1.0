using Moq;
using SiteX.Data.Common.Repositories;
using SiteX.Services.Data.ArticleService;
using SiteX.Data.Models.Article;
using SiteX.Data.Models.Team;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SiteX.Services.Data.Tests.Articles
{
    public class EditArticle
    {

        [Fact]
        public async Task EditArticleShouldEditTheGiveArticle()
        {
            var list = new List<Article>();

            var mockProductRepo = new Mock<IDeletableEntityRepository<Article>>();

            mockProductRepo.Setup(x => x.All()).Returns(list.AsQueryable());

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
            var edit = new Article() { Title = "Edited Title", Abstract = "Edited Text", Id = 1 };
            await service.EditArticleAsync(edit);

            Assert.True(list[1].Title == "Edited Title");
            Assert.True(list[1].Abstract == "Edited Text");
        }
    }
}
