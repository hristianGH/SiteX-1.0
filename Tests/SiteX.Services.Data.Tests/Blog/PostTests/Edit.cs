namespace SiteX.Services.Data.Tests.Blog.PostTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Moq;
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models;
    using SiteX.Data.Models.Blog;
    using SiteX.Services.Data.BlogService;
    using SiteX.Services.Data.BlogService.Interface;
    using SiteX.Web.ViewModels.BlogViewModels;
    using Xunit;

    public class Edit
    {
        [Fact]
        public async Task EditPostShouldEditTheGivenPost()
        {
            var listPosts = new List<Post>();
            var listGenres = new List<PostGenre>();

            var mockRepo = new Mock<IDeletableEntityRepository<Post>>();
            var mockGenreRepo = new Mock<IDeletableEntityRepository<PostGenre>>();

            mockRepo.Setup(x => x.All()).Returns(listPosts.AsQueryable());
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
                User = new ApplicationUser() { Id = "id" },
                PostGenres = new int[] { 1, 2 },
            };
            await service.CreatePostAsync(post);
            listPosts[0].Id = 1;
            Assert.Contains(listPosts, x => x.Body == "Text");
            Assert.Contains(listPosts, x => x.Title == "Title");

            var editModel = new PostEditViewModel()
            {
                Body = "Body Edited",
                Title = "Title Edited",
                PostImages = new string[] { "image1", "image2" },
                PostGenres = new int[] { 1, 2 },
                Id = 1,
            };
            await service.EditPostAsync(editModel);

            Assert.True(listPosts.First().Title == "Title Edited");
            Assert.True(listPosts.First().Body == "Body Edited");
        }
    }
}
