namespace SiteX.Services.Data.BlogService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Blog;
    using SiteX.Services.Data.BlogService.Interface;

    public class PostImageService : IPostImageService
    {
        private readonly IDeletableEntityRepository<PostImage> postImageRepo;

        public PostImageService(IDeletableEntityRepository<PostImage> postImageRepo)
        {
            this.postImageRepo = postImageRepo;
        }

        public ICollection<PostImage> GetImagesByPostId(int id)
        {
            return this.postImageRepo.AllAsNoTracking().Where(x => x.PostId == id).ToList();
        }

        public async Task HardDeletePostImagesByIdAsync(int postId)
        {
            var images = this.postImageRepo.All().Where(x => x.PostId == postId).ToList();

            foreach (var image in images)
            {
                this.postImageRepo.HardDelete(image);
            }

            await this.postImageRepo.SaveChangesAsync();
        }

        public async Task CreatingPostImageAsync(ICollection<string> paths, int postId)
        {
            foreach (var item in paths)
            {
                var entity = new PostImage();
                entity.PostId = postId;
                entity.Path = item;
                await this.postImageRepo.AddAsync(entity);
            }

            await this.postImageRepo.SaveChangesAsync();
        }
    }
}
