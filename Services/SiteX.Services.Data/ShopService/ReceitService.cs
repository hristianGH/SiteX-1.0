namespace SiteX.Services.Data.ShopService
{
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService.Interface;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class ReceitService : IReceitService
    {
        private readonly IRepository<Receit> receitRepo;

        public ReceitService(IRepository<Receit> receitRepo)
        {
            this.receitRepo = receitRepo;
        }
        public async Task CreateAsync(Receit receit)
        {
            await this.receitRepo.AddAsync(receit);
            await this.receitRepo.SaveChangesAsync();
        }

        public Receit GetById(Guid id)
        {
            return this.receitRepo.AllAsNoTracking().FirstOrDefault(x => x.Id == id);
        }
    }
}
