namespace SiteX.Services.Data.ShopService
{
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService.Interface;
    using SiteX.Web.ViewModels.ShopViewModels.SizeModels;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SizeService : ISizeService
    {
        private readonly IRepository<Size> sizeRepo;

        public SizeService(IRepository<Size> sizeRepo)
        {
            this.sizeRepo = sizeRepo;
        }

        public async Task CreateAsync(SizeViewModel viewModel)
        {
            var size = new Size() { Name = viewModel.Name };
            await this.sizeRepo.AddAsync(size);
            await this.sizeRepo.SaveChangesAsync();
        }

        public async Task EditSizeAsync(Size model)
        {
            var viewmodel = this.sizeRepo.All().Where(x => x.Id == model.Id).FirstOrDefault();
            viewmodel.Name = model.Name;
            await this.sizeRepo.SaveChangesAsync();
        }

        public Size GetSizeById(int id)
        {
            return this.sizeRepo.All().Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Size> GetSizes()
        {
            var sizes = this.sizeRepo.AllAsNoTracking().ToList();
            return sizes;
        }

        public int GetSizesCount()
        {
            return this.sizeRepo.AllAsNoTracking().Count();
        }
    }
}
