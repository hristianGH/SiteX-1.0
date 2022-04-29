namespace SiteX.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using SiteX.Data.Models.Shop;

    public class GenderSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Genders.Any())
            {
                return;
            }

            await dbContext.Genders.AddAsync(new Gender { Name = "Male" });
            await dbContext.Genders.AddAsync(new Gender { Name = "Female" });
            await dbContext.Genders.AddAsync(new Gender { Name = "Unisex" });
        }
    }
}
