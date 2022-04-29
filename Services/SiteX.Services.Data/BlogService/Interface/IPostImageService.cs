namespace SiteX.Services.Data.BlogService.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SiteX.Data.Models.Blog;

    public interface IPostImageService
    {

        public ICollection<PostImage> GetImagesByPostId(int id);

        public Task HardDeletePostImagesByIdAsync(int productId);

        public Task CreatingPostImageAsync(ICollection<string> paths, int product);
    }
}
