namespace SiteX.Services.Data.BlogService.Interface
{
    using SiteX.Data.Models.Blog;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPostImageService
    {

        public ICollection<PostImage> GetImagesByPostId(int id);

        public Task HardDeletePostImagesByIdAsync(int productId);

        public Task CreatingPostImageAsync(ICollection<string> paths, int product);
    }
}
