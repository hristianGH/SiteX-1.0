namespace SiteX.Services.Data.BlogService
{
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Blog;
    using SiteX.Services.Data.BlogService.Interface;
    using SiteX.Services.Mapping;
    using SiteX.Web.ViewModels.BlogViewModels;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PostService : IPostService
    {
        private readonly IDeletableEntityRepository<Post> postRepo;
        private readonly IPostGenreService postGenreService;

        public PostService(
            IDeletableEntityRepository<Post> postRepo,
            IPostGenreService postGenreService)
        {
            this.postRepo = postRepo;
            this.postGenreService = postGenreService;
        }

        public async Task CreatePostAsync(PostViewModel viewModel)
        {
            var pics = new List<PostImage>();
            foreach (var pic in viewModel.PostImages.Where(x => x != null))
            {
                pics.Add(new PostImage() { Path = pic });
            }

            var post = new Post()
            {
                Body = viewModel.Body,
                Title = viewModel.Title,
                PostImages = pics,
                User = viewModel.User,
                UserId = viewModel.User.Id,
            };

            await this.postRepo.AddAsync(post);
            await this.postRepo.SaveChangesAsync();
            await this.postGenreService.CreatingPostGenreAsync(viewModel.PostGenres, post.Id);
        }

        public int GetPostCount()
        {
            return this.postRepo.AllAsNoTracking().Count();
        }

        public ICollection<PostOutViewModel> GetAllPostsAsOutModel()
        {
            return this.postRepo.AllAsNoTracking().OrderByDescending(x => x.CreatedOn)
                .To<PostOutViewModel>().ToList();
        }

        public ICollection<PostOutViewModel> FilterByGenreId(int id)
        {
            return this.GetAllPostsAsOutModel().Where(x => x.Genres.Any(x => x.Id == id)).ToList();
        }

        public ICollection<PostOutViewModel> ToPage(int page = 1, int itemsPerPage = 6)
        {
            return this.GetAllPostsAsOutModel().Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToList();
        }

        public PostOutViewModel GetOutputPostById(int id)
        {
            return this.postRepo.AllAsNoTracking().To<PostOutViewModel>().FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Post> GetPosts()
        {
            return this.postRepo.AllAsNoTracking().ToList();
        }

        public async Task EditPostAsync(PostEditViewModel post)
        {
            var edit = this.postRepo.All().Where(x => x.Id == post.Id).FirstOrDefault();
            edit.Title = post.Title;
            edit.Body = post.Body;

            await this.postRepo.SaveChangesAsync();

            await this.HardDeleteConnectionsByPostIdAsync(post.Id);
            await this.CreateConnectionsByModelAsync(post, post.Id);
        }

        public Post GetPostById(int id)
        {
            return this.postRepo.AllAsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public PostEditViewModel GetEditPostById(int id)
        {
            var edit = this.postRepo.AllAsNoTracking().Select(x => new PostEditViewModel
            {
                Id = x.Id,
                Title = x.Title,
                PostGenres = x.PostGenres.Select(x => x.Genre.Id).ToList(),
                PostImages = x.PostImages.Select(x => x.Path).ToList(),
                Body = x.Body,
            }).Where(x => x.Id == id).FirstOrDefault();

            return edit;
        }

        public async Task HardDeleteConnectionsByPostIdAsync(int id)
        {
            await this.postGenreService.HardDeletePostGenreByIdAsync(id);
        }

        public async Task CreateConnectionsByModelAsync(PostEditViewModel list, int id)
        {
            await this.postGenreService.CreatingPostGenreAsync(list.PostGenres, id);
        }

        public async Task HardDeletePostAsync(Post viewModel)
        {
            this.postRepo.HardDelete(viewModel);
            await this.postRepo.SaveChangesAsync();
        }

        public async Task SoftDeletePostAsync(int id)
        {
            var post = this.GetPostById(id);
            this.postRepo.Delete(post);
            await this.postRepo.SaveChangesAsync();
        }
    }
}
