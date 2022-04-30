namespace SiteX.Services.Data.BlogService.Interface
{
    using SiteX.Data.Models.Blog;
    using SiteX.Web.ViewModels.BlogViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPostService
    {
        public Task CreatePostAsync(PostViewModel viewModel);

        public Task HardDeletePostAsync(Post viewModel);

        public Task SoftDeletePostAsync(int id);

        public PostEditViewModel GetEditPostById(int id);

        public ICollection<Post> GetPosts();

        public int GetPostCount();

        public Task EditPostAsync(PostEditViewModel viewModel);

        public Post GetPostById(int id);

        public ICollection<PostOutViewModel> GetAllPostsAsOutModel();

        public ICollection<PostOutViewModel> ToPage(int page = 1, int itemsPerPage = 6);

        public PostOutViewModel GetOutputPostById(int id);

        public Task HardDeleteConnectionsByPostIdAsync(int id);

        public Task CreateConnectionsByModelAsync(PostEditViewModel list, int id);

        public ICollection<PostOutViewModel> FilterByGenreId(int id);
    }
}
