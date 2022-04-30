namespace SiteX.Data.Seeding
{
    using SiteX.Data.Models.Shop;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SizeSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Sizes.Any())
            {
                return;
            }

            var sizes = new List<Size>();
            sizes.Add(new Size() { Name = "S" });
            sizes.Add(new Size() { Name = "M" });
            sizes.Add(new Size() { Name = "L" });
            sizes.Add(new Size() { Name = "XL" });
            sizes.Add(new Size() { Name = "XLL" });
            sizes.Add(new Size() { Name = "XLLL" });
            foreach (var item in sizes)
            {
                await dbContext.AddAsync(item);
            }
        }
    }
}
