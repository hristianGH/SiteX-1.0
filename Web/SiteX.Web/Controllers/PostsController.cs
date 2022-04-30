namespace SiteX.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SiteX.Data.Models;
    using SiteX.Services.Data.BlogService.Interface;
    using SiteX.Web.ViewModels.BlogViewModels;

    public class PostsController : Controller
    {
        private readonly IPostService postService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPostImageService postImageService;
        private readonly IPostListService toListService;
        private readonly ICommentService commentService;

        public PostsController(
            IPostService postService,
            UserManager<ApplicationUser> userManager,
            IPostImageService postImageService,
            IPostListService toListService,
            ICommentService commentService)
        {
            this.postService = postService;
            this.userManager = userManager;
            this.postImageService = postImageService;
            this.toListService = toListService;
            this.commentService = commentService;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }

        public IActionResult All(int id = 1)
        {
            PostAllViewModel postViewModel = new PostAllViewModel() { Posts = this.postService.ToPage(id, 6), PageNumber = id, ItemsPerPage = 8 };

            postViewModel.ItemsCount = this.postService.GetPostCount();
            postViewModel.ToSelectList = this.toListService.ToSelectedList();

            return this.View(postViewModel);
        }

        public IActionResult ById(int id)
        {
            var post = this.postService.GetOutputPostById(id);
            this.ViewBag.ImageOne = this.postImageService.GetImagesByPostId(id).Select(x => x.Path).FirstOrDefault();
            this.ViewBag.Images = this.postImageService.GetImagesByPostId(id).Select(x => x.Path).Skip(1);
            post.Comments = this.commentService.GetCommentsByPostId(id);
            return this.View(post);
        }

        public IActionResult SearchByGenre(int id = 1)
        {
            PostAllViewModel postViewModel = new PostAllViewModel()
            {
                Posts = this.postService.FilterByGenreId(id),
            };
            postViewModel.ItemsCount = this.postService.GetPostCount();
            postViewModel.ToSelectList = this.toListService.ToSelectedList();

            if (postViewModel != null)
            {
                return this.View("All", postViewModel);
            }

            return this.NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentViewModel viewModel)
        {
            viewModel.User = await this.userManager.GetUserAsync(this.User);

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var parentId =
                 viewModel.ParentId == 0 ?
                     (int?)null :
                     viewModel.ParentId;

            if (parentId.HasValue)
            {
                if (!this.commentService.IsInPostId(parentId.Value, viewModel.PostId))
                {
                    return this.BadRequest();
                }
            }

            await this.commentService.CreateAsync(viewModel);
            return this.RedirectToAction("All");
        }
    }
}
