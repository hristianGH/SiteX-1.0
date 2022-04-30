namespace SiteX.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using SiteX.Data.Models.Blog;

    public class PostSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Users.Count() > 0 && dbContext.Posts.Count() <= 1)
            {
                var post = new Post
                {
                    Title = "Grand opening of our online shop SiteX",
                    Body = "This online shop is like no other.Our locations are all over the world.You are welcomed at every single one of them.How lucky.",
                };
                post.PostImages.Add(new PostImage() { PostId = post.Id, Path = "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fstatic.vecteezy.com%2Fsystem%2Fresources%2Fpreviews%2F000%2F084%2F732%2Foriginal%2Fvector-grand-opening-retro-style-background.jpg&f=1&nofb=1" });
                post.PostGenres.Add(new PostGenre() { PostId = post.Id, GenreId = 1 });

                await dbContext.Posts.AddAsync(post);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
