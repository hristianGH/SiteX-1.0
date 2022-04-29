using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteX.Data.Models.Blog;
using SiteX.Services.Data.BlogService.Interface;
using SiteX.Web.ViewModels.BlogViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SiteX.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        // GET: api/<CommentController>
        [HttpGet("All")]
        public IEnumerable<Comment> GetAll()
        {
            return this.commentService.GetComents();
        }

        // GET api/<CommentController>/5
        [HttpGet("GetBy{id}")]
        public async Task<Comment> GetById(int id)
        {
            return await this.commentService.GetCommentByIdAsync(id);
        }

        // POST api/<CommentController>
        [HttpPost("Create")]
        public async Task<IActionResult> Post(CommentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
           await commentService.CreateAsync(viewModel);
            return Ok();

        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!commentService.DoesCommentExistById(id))
            {
                return NotFound();
            }
          await  commentService.DeleteAsync(id);
            return Ok();
        }
    }
}
