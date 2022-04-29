namespace SiteX.Services.Data.BlogService.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPostGenreService
    {
        public Task CreatingPostGenreAsync(ICollection<int> genres, int post);

        public Task HardDeletePostGenreByIdAsync(int postid);

    }
}
