namespace SiteX.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using SiteX.Data.Models;
    using SiteX.Services.Data.BlogService.Interface;
    using SiteX.Web.ViewModels.BlogViewModels;

    public class PostsController : AdministrationController
    {
        private readonly IPostService postService;
        private readonly IGenreService genreService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostsController(
            IPostService postService,
            IGenreService genreService,
            UserManager<ApplicationUser> userManager)
        {
            this.postService = postService;
            this.genreService = genreService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var posts = this.postService.GetPosts();
            return this.View(posts);
        }

        public IActionResult Edit(int id)
        {
            var viewModel = this.postService.GetEditPostById(id);

            if (viewModel.PostImages.Count() == 0)
            {
                viewModel.PostImages.Add(string.Empty);
            }

            viewModel.GenresToList = this.genreService.GetGenres();

            this.ViewBag.ProductId = viewModel.Id;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostEditViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.postService.EditPostAsync(viewModel);

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var viewModel = this.postService.GetOutputPostById(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, PostOutViewModel post)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.postService.SoftDeletePostAsync(post.Id);
            return this.RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            this.ViewBag.Genres = new SelectList(this.genreService.GetGenres(), "Id", "Name");
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            viewModel.User = await this.userManager.GetUserAsync(this.User);
            await this.postService.CreatePostAsync(viewModel);

            return this.RedirectToAction("Index");
        }
    }
}
