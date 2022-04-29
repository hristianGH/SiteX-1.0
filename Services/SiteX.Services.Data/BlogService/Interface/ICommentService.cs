namespace SiteX.Services.Data.BlogService.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SiteX.Data.Models.Blog;
    using SiteX.Web.ViewModels.BlogViewModels;

    public interface ICommentService
    {
        public IEnumerable<Comment> GetComents();

        public Task CreateAsync(CommentViewModel comment);


        public ICollection<Comment> GetCommentsByPostId(int id);

        public bool IsInPostId(int commentId, int postId);

        public Task<Comment> GetCommentByIdAsync(int id);

        public Task DeleteAsync(int id);

        public bool DoesCommentExistById(int id);

        public Task EditCommentAsync(Comment comment);
    }
}
