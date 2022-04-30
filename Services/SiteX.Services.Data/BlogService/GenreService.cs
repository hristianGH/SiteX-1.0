namespace SiteX.Services.Data.BlogService
{
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Blog;
    using SiteX.Services.Data.BlogService.Interface;
    using SiteX.Web.ViewModels.BlogViewModels;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GenreService : IGenreService
    {
        private readonly IRepository<Genre> genreRepo;

        public GenreService(IRepository<Genre> genreRepo)
        {
            this.genreRepo = genreRepo;
        }

        public async Task CreateAsync(GenreViewModel viewModel)
        {
            var genre = new Genre() { Name = viewModel.Name };
            await this.genreRepo.AddAsync(genre);
            await this.genreRepo.SaveChangesAsync();
        }

        public async Task EditAsync(Genre genre)
        {
            var edit = this.genreRepo.All().Where(x => x.Id == genre.Id).FirstOrDefault();
            edit.Name = genre.Name;
            await this.genreRepo.SaveChangesAsync();
        }

        public IEnumerable<Genre> GetGenres()
        {
            var genres = this.genreRepo.AllAsNoTracking().ToList();
            return genres;
        }

        public Genre GetGenreById(int id)
        {
            return this.genreRepo.AllAsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
