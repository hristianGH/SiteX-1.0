namespace SiteX.Services.Data.BlogService
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Blog;
    using SiteX.Services.Data.BlogService.Interface;

    public class PostGenreSevice : IPostGenreService
    {
        private readonly IDeletableEntityRepository<PostGenre> postGenreRepository;

        public PostGenreSevice(IDeletableEntityRepository<PostGenre> postGenreRepository)
        {
            this.postGenreRepository = postGenreRepository;
        }

        public async Task CreatingPostGenreAsync(ICollection<int> genres, int post)
        {
            foreach (var item in genres)
            {
                var entity = new PostGenre();
                entity.PostId = post;
                entity.GenreId = item;

                await this.postGenreRepository.AddAsync(entity);
            }

            await this.postGenreRepository.SaveChangesAsync();
        }

        public async Task HardDeletePostGenreByIdAsync(int postid)
        {
            var locations = this.postGenreRepository.All().Where(x => x.PostId == postid).ToList();

            foreach (var location in locations)
            {
                this.postGenreRepository.HardDelete(location);
            }

            await this.postGenreRepository.SaveChangesAsync();
        }
    }
}
