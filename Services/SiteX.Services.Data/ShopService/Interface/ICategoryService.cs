namespace SiteX.Services.Data.ShopService.Interface
{
    using SiteX.Data.Models.Shop;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        public IEnumerable<Category> GetCategories();

        public Category GetCategoryById(int id);

        public Task EditCategoryAsync(Category category);

        public Task CreateAsync(Category viewModel);

        public int GetCategoryCount();
    }
}
