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

    public class GetOutputPost
    {
        [Fact]
        public async Task GetAllPostAsOutViewModelShouldReturnPostAsOutViewModel()
        {
            if (AutoMapperConfig.MapperInstance == null)
            {
                AutoMapperConfig.RegisterMappings(typeof(IndexViewModel).GetTypeInfo().Assembly);
            }

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

            for (int i = 0; i < 5; i++)
            {
                var post = new PostViewModel()
                {
                    Body = $"Text {i}",
                    Title = $"Title {i}",
                    PostImages = new string[] { "image1", "image2" },
                    PostGenres = new int[] { 1, 2 },
                    User = new ApplicationUser() { Id = $"{i}" },
                };
                await service.CreatePostAsync(post);
                listPosts[i].Id = i;
            }

            var outViewModels = service.GetAllPostsAsOutModel();

            Assert.True(outViewModels != null);
            Assert.True(outViewModels.Count == 5);
        }

        [Fact]
        public async Task GetOutputPostByIdShouldReturnOutput()
        {
            if (AutoMapperConfig.MapperInstance == null)
            {
                AutoMapperConfig.RegisterMappings(typeof(IndexViewModel).GetTypeInfo().Assembly);
            }

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

            for (int i = 0; i < 5; i++)
            {
                var post = new PostViewModel()
                {
                    Body = $"Text {i}",
                    Title = $"Title {i}",
                    PostImages = new string[] { "image1", "image2" },
                    PostGenres = new int[] { 1, 2 },
                    User = new ApplicationUser() { Id = $"{i}" },
                };
                await service.CreatePostAsync(post);
                listPosts[i].Id = i;
            }

            var outViewModel = service.GetOutputPostById(3);

            Assert.True(outViewModel != null);
            Assert.True(outViewModel.Id == 3);
        }
    }
}
