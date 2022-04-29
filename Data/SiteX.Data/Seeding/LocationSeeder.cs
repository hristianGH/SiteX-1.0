namespace SiteX.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using SiteX.Data.Models.Shop;

    public class LocationSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Locations.Any())
            {
                return;
            }

            List<Location> locations = new List<Location>();
            locations.Add(new Location() { Name = "Big SiteX", Address = "Sofia/Bulgaria" });
            locations.Add(new Location() { Name = "Small SiteX", Address = "Plovdiv/Bulgaria" });
            locations.Add(new Location() { Name = "Medium SiteX", Address = "London/England" });
            locations.Add(new Location() { Name = "Big SiteX", Address = "Paris/France" });
            locations.Add(new Location() { Name = "Small SiteX", Address = "Florida/Hell" });
            foreach (var item in locations)
            {
                await dbContext.Locations.AddAsync(item);
            }
        }
    }
}
