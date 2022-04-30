namespace SiteX.Services.Data.BlogService.Interface
{
    using SiteX.Data.Models.Blog;
    using SiteX.Web.ViewModels.BlogViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGenreService
    {
        public Task CreateAsync(GenreViewModel viewModel);

        public Task EditAsync(Genre genre);

        public IEnumerable<Genre> GetGenres();

        public Genre GetGenreById(int id);

    }
}
