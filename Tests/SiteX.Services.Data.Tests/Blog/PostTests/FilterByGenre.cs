namespace SiteX.Services.Data.Tests.Blog.PostTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Moq;
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models;
    using SiteX.Data.Models.Blog;
    using SiteX.Services.Data.BlogService;
    using SiteX.Services.Data.BlogService.Interface;
    using SiteX.Services.Mapping;
    using SiteX.Web.ViewModels;
    using SiteX.Web.ViewModels.BlogViewModels;
    using Xunit;

    public class FilterByGenre
    {
        // IF It returns Fail Run by itself
        [Fact]
        public async Task ProductFilterByCategorySholdFilter()
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
            for (int i = 0; i <= 3; i++)
            {
                var post = new PostViewModel()
                {
                    Body = "Text",
                    Title = "Title",
                    PostImages = new string[] { "image1", "image2" },
                    User = new ApplicationUser() { Id = "id" },
                };
                await service.CreatePostAsync(post);
                listPosts[i].PostGenres.Add(new PostGenre { Genre = new Genre() { Id = 1 } });
            }

            for (int i = 4; i <= 6; i++)
            {
                var postWithRightCategories = new PostViewModel()
                {
                    Body = "Text",
                    Title = "Title",
                    PostImages = new string[] { "image1", "image2" },
                    User = new ApplicationUser() { Id = "id" },
                };
                await service.CreatePostAsync(postWithRightCategories);
                listPosts[i].PostGenres.Add(new PostGenre { Genre = new Genre() { Id = 4 } });
            }

            var filtered = service.FilterByGenreId(4);
            Assert.True(filtered.Count() == 3);
            foreach (var prod in filtered)
            {
                Assert.Contains(prod.Genres, x => x.Id == 4);
            }
        }
    }
}
