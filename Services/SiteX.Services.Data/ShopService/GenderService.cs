namespace SiteX.Services.Data.ShopService
{
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService.Interface;
    using System.Collections.Generic;
    using System.Linq;

    public class GenderService : IGenderService
    {
        private readonly IRepository<Gender> genderRepository;

        public GenderService(IRepository<Gender> repository)
        {
            this.genderRepository = repository;
        }

        public IEnumerable<string> GetGenders()
        {
            var genders = this.genderRepository.AllAsNoTracking().Select(x => x.Name).ToArray();
            return genders;
        }
    }
}
