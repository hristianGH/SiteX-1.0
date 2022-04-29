using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteX.Services.Data.BlogService.Interface;
using SiteX.Web.ViewModels.BlogViewModels;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SiteX.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;

        public PostController(IPostService postService )
        {
            this.postService = postService;
        }
        [HttpGet("GetPosts")]
        public IActionResult Index()
        {
            var posts = this.postService.GetPosts();
            return this.Ok(posts);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(PostEditViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.postService.EditPostAsync(viewModel);

            return this.Ok(viewModel);
        }

    }
}
