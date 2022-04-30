namespace SiteX.Services.Data.ShopService
{
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService.Interface;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ColorService : IColorService
    {
        private readonly IRepository<Color> colorRepo;

        public ColorService(
            IRepository<Color> colorRepo)
        {
            this.colorRepo = colorRepo;
        }

        public async Task CreateAsync(Color viewModel)
        {
            var color = new Color() { Name = viewModel.Name };
            await this.colorRepo.AddAsync(color);
            await this.colorRepo.SaveChangesAsync();
        }

        public async Task EditColorAsync(Color color)
        {
            var editColor = this.colorRepo.All().Where(x => x.Id == color.Id).FirstOrDefault();
            editColor.Name = color.Name;

            await this.colorRepo.SaveChangesAsync();
        }

        public Color GetColorById(int id)
        {
            return this.colorRepo.AllAsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Color> GetColors()
        {
            var colors = this.colorRepo.AllAsNoTracking().ToList();
            return colors;
        }

        public int GetColorsCount()
        {
            return this.colorRepo.AllAsNoTracking().Count();
        }
    }
}
