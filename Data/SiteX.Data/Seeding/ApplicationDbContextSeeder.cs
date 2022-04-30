namespace SiteX.Data.Seeding
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using SiteX.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class ApplicationDbContextSeeder : ISeeder
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ApplicationDbContextSeeder(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public ApplicationDbContextSeeder()
        {
        }

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger(typeof(ApplicationDbContextSeeder));

            var seeders = new List<ISeeder>
                          {
                              new RolesSeeder(),
                              new SettingsSeeder(),
                              new UserSeeder(this.userManager),
                              new CategorySeeder(),
                              new LocationSeeder(),
                              new GenderSeeder(),
                              new GenreSeeder(),
                              new SizeSeeder(),
                              new PostSeeder(),
                              new ColorSeeder(),
                              new ProductSeeder(),
                              new ArticleSeeder(),
                          };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
                logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
            }
        }
    }
}
