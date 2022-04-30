namespace SiteX.Data.Seeding
{
    using SiteX.Data.Models.Shop;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    [ExcludeFromCodeCoverage]
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
