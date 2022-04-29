using Moq;
using SiteX.Data.Common.Repositories;
using SiteX.Data.Models.Shop;
using SiteX.Services.Data.ShopService;
using SiteX.Web.ViewModels.ShopViewModels.CategoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SiteX.Services.Data.Tests.Shop.CategoryTests
{
    public class EditCategory
    {
        [Fact]
        public async Task CategoryEditShouldChangeName()
        {
            var list = new List<Category>();

            var mockRepo = new Mock<IRepository<Category>>();

            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Category>())).Callback((Category x) => list.Add(x));
            var service = new CategoryService(mockRepo.Object);

            var oldName = "Before Edit";
            var name = "After Edit";
            var category = new Category() {Id=1,Name = oldName };
            list.Add(category);
            
            var categoryEdit = new Category() { Id = 1, Name = name };
            await service.EditCategoryAsync(categoryEdit);

            Assert.Equal(name, list[0].Name);
        }
    }
}
