namespace SiteX.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using SiteX.Data.Models.Blog;

    public class GenreSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Genres.Any())
            {
                return;
            }

            await dbContext.AddAsync(new Genre { Name = "Life and Living" });
            await dbContext.AddAsync(new Genre { Name = "Life and Dying" });
            await dbContext.AddAsync(new Genre { Name = "Life and Health" });
            await dbContext.AddAsync(new Genre { Name = "Tech and Living" });
            await dbContext.AddAsync(new Genre { Name = "Tech and Dying" });
            await dbContext.AddAsync(new Genre { Name = "Tech and Health" });
            await dbContext.AddAsync(new Genre { Name = "Misc" });
        }
    }
}
