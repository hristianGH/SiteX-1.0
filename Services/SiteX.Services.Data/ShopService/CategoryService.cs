namespace SiteX.Services.Data.ShopService
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService.Interface;

    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoryService(
            IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetCategories()
        {
            var category = this.categoryRepository.AllAsNoTracking().ToArray();
            return category;
        }

        public async Task CreateAsync(Category viewModel)
        {
            var category = new Category() { Name = viewModel.Name };
            await this.categoryRepository.AddAsync(category);
            await this.categoryRepository.SaveChangesAsync();
        }

        public int GetCategoryCount()
        {
            return this.categoryRepository.AllAsNoTracking().Count();
        }

        public Category GetCategoryById(int id)
        {
            return this.categoryRepository.AllAsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task EditCategoryAsync(Category category)
        {
            var categoryEdit = this.categoryRepository.All().FirstOrDefault(x => x.Id == category.Id);
            if (categoryEdit != null)
            {
                categoryEdit.Name = category.Name;
                await this.categoryRepository.SaveChangesAsync();
            }
        }
    }
}
