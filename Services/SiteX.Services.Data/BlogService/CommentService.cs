namespace SiteX.Services.Data.BlogService
{
    using Microsoft.AspNetCore.Identity;
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models;
    using SiteX.Data.Models.Blog;
    using SiteX.Services.Data.BlogService.Interface;
    using SiteX.Web.ViewModels.BlogViewModels;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CommentService : ICommentService
    {
        private readonly IDeletableEntityRepository<Comment> commentRepo;
        private readonly UserManager<ApplicationUser> userManager;

        public CommentService(
            IDeletableEntityRepository<Comment> commentRepo,
            UserManager<ApplicationUser> userManager)
        {
            this.commentRepo = commentRepo;
            this.userManager = userManager;
        }

        public async Task CreateAsync(CommentViewModel viewModel)
        {
            if (viewModel.ParentId == 0)
            {
                viewModel.ParentId = null;
            }

            Comment comment = new Comment()
            {
                Body = viewModel.Body,
                Post = viewModel.Post,
                User = viewModel.User,
                ParentId = viewModel.ParentId,
                PostId = viewModel.PostId,
                UserId = viewModel.User.Id,
            };
            await this.commentRepo.AddAsync(comment);
            await this.commentRepo.SaveChangesAsync();
        }

        public IEnumerable<Comment> GetComents()
        {
            return this.commentRepo.AllAsNoTracking().ToList();
        }

        public ICollection<Comment> GetCommentsByPostId(int id)
        {
            var list = this.commentRepo.AllAsNoTracking().Select(x => new Comment
            {
                Id = x.Id,
                UserId = x.UserId,
                PostId = x.PostId,
                User = x.User,
                Body = x.Body,
                ParentId = x.ParentId,
                Parent = x.Parent,
                Post = x.Post,
                CreatedOn = x.CreatedOn,
            }).Where(x => x.Post.Id == id).ToList();

            return list;
        }

        public bool IsInPostId(int commentId, int postId)
        {
            var commentPostId = this.commentRepo.All().Where(x => x.Id == commentId)
                .Select(x => x.PostId).FirstOrDefault();
            return commentPostId == postId;
        }

        public async Task<Comment> GetCommentByIdAsync(int id)
        {
            var comment = this.commentRepo.AllAsNoTracking().FirstOrDefault(x => x.Id == id);
            comment.User = await this.userManager.FindByIdAsync(comment.UserId);

            return comment;
        }

        public async Task DeleteAsync(int id)
        {
            var comment = this.commentRepo.All().FirstOrDefault(x => x.Id == id);
            this.commentRepo.Delete(comment);
            await this.commentRepo.SaveChangesAsync();
        }

        public bool DoesCommentExistById(int id)
        {
            return this.commentRepo.AllAsNoTracking().Any(x => x.Id == id);
        }

        public async Task EditCommentAsync(Comment comment)
        {
            var edit = this.commentRepo.All().FirstOrDefault(x => x.Id == comment.Id);
            edit.Body = comment.Body;
            await this.commentRepo.SaveChangesAsync();
        }
    }
}
