namespace SiteX.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using SiteX.Data.Models.Blog;
    using SiteX.Services.Data.BlogService.Interface;

    public class CommentsController : AdministrationController
    {
        private readonly ICommentService commentService;

        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        // GET: CommentsController
        public IActionResult Index()
        {
            var comments = this.commentService.GetComents();
            return this.View(comments);
        }

        // GET: CommentsController/Details/5
        public ActionResult Details(int id)
        {
            return this.View();
        }

        // GET: CommentsController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var comment = await this.commentService.GetCommentByIdAsync(id);
            return this.View(comment);
        }

        // POST: CommentsController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Comment comment)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.commentService.EditCommentAsync(comment);
            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: CommentsController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await this.commentService.GetCommentByIdAsync(id);
            return this.View(comment);
        }

        // POST: CommentsController/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(Comment comment)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.commentService.DeleteAsync(comment.Id);
            return this.RedirectToAction("Index");
        }
    }
}
