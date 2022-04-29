using Moq;
using SiteX.Data.Common.Repositories;
using SiteX.Data.Models;
using SiteX.Data.Models.Blog;
using SiteX.Services.Data.BlogService;
using SiteX.Services.Data.BlogService.Interface;
using SiteX.Web.ViewModels.BlogViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SiteX.Services.Data.Tests.Blog.PostTests
{
    public class Create
    {
        [Fact]
        public async Task CreatePostShouldAddProductToRepo()
        {
            var listPosts = new List<Post>();
            var listGenres = new List<PostGenre>();

            var mockRepo = new Mock<IDeletableEntityRepository<Post>>();
            var mockGenreRepo = new Mock<IDeletableEntityRepository<PostGenre>>();

            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(listPosts.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post x) => listPosts.Add(x));

            mockGenreRepo.Setup(x => x.AllAsNoTracking()).Returns(listGenres.AsQueryable());
            mockGenreRepo.Setup(x => x.AddAsync(It.IsAny<PostGenre>())).Callback((PostGenre x) => listGenres.Add(x));

            IPostGenreService genreService = new PostGenreSevice(mockGenreRepo.Object);
            var service = new PostService(mockRepo.Object, genreService);

            var post = new PostViewModel()
            {
                Body = "Text",
                Title = "Title",
                PostImages = new string[] { "image1", "image2" },
                PostGenres = new int[] { 1, 2 },
                User = new ApplicationUser() { Id="id"},
            };
            await service.CreatePostAsync(post);
            Assert.True(listPosts.Any(x => x.Body == "Text"));
            Assert.True(listPosts.Any(x => x.Title == "Title"));
        }
    }
}
