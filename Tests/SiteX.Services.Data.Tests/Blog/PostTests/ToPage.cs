using Moq;
using SiteX.Data.Common.Repositories;
using SiteX.Data.Models;
using SiteX.Data.Models.Blog;
using SiteX.Services.Data.BlogService;
using SiteX.Services.Data.BlogService.Interface;
using SiteX.Services.Mapping;
using SiteX.Web.ViewModels;
using SiteX.Web.ViewModels.BlogViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SiteX.Services.Data.Tests.Blog.PostTests
{
    public class ToPage
    {
        //IF It returns Fail Run by itself

        [Fact]
        public async Task ToPageSholdWork()
        {
            var listPosts = new List<Post>();
            var listGenres = new List<PostGenre>();
            if (AutoMapperConfig.MapperInstance == null)
            {
                AutoMapperConfig.RegisterMappings(typeof(IndexViewModel).GetTypeInfo().Assembly);
            }

            var mockRepo = new Mock<IDeletableEntityRepository<Post>>();
            var mockGenreRepo = new Mock<IDeletableEntityRepository<PostGenre>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(listPosts.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post x) => listPosts.Add(x));

            mockGenreRepo.Setup(x => x.AllAsNoTracking()).Returns(listGenres.AsQueryable());
            mockGenreRepo.Setup(x => x.AddAsync(It.IsAny<PostGenre>())).Callback((PostGenre x) => listGenres.Add(x));

            IPostGenreService genreService = new PostGenreSevice(mockGenreRepo.Object);
            var service = new PostService(mockRepo.Object, genreService);

            for (int i = 0; i < 13; i++)
            {
                var post = new PostViewModel()
                {
                    Body = "Text",
                    Title = "Title",
                    PostImages = new string[] { "image1", "image2" },
                    PostGenres = new int[] { 1, 2 },
                    User = new ApplicationUser() { Id = "id" },
                };
                await service.CreatePostAsync(post);
                listPosts[i].Id=i;
            }

            for (int page = 1; page <= 20; page++)
            {
                var currentPage = service.ToPage(page, 6);
                if (Math.Ceiling((double)listPosts.Count / 6) >= page)
                {
                    Assert.True(currentPage.Any());
                    Assert.True(currentPage != null);
                }
                else
                {
                    Assert.True(currentPage.Count == 0);
                }
                
            }
        }
    }
}
