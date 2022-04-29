namespace SiteX.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using SiteX.Data.Models.Shop;

    internal class CategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            List<Category> categories = new List<Category>();
            categories.Add(new Category() { Name = "T-shirt/Top" });
            categories.Add(new Category() { Name = "Shorts" });
            categories.Add(new Category() { Name = "Hoodies" });
            categories.Add(new Category() { Name = "Tanks" });
            categories.Add(new Category() { Name = "Bottoms" });
            foreach (var item in categories)
            {
                await dbContext.Categories.AddAsync(item);
            }
        }
    }
}
