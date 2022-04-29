﻿using Moq;
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
    public class GetArticles
    {
        [Fact]
        public async Task GetArticlesShouldReturnAllArticlesFromRepostiroy()
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

            var articles = service.GetArticles();

            Assert.NotEmpty(articles);
            Assert.True(articles.First().Title == "Title");
            Assert.True(articles.First().Abstract == "Some Text");
        }
    }
}
