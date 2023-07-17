using System;
using BussinessObject.Models;
using DataAccess.Infrastructure;

namespace DataAccess.CommentRepository
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        IList<Comment> GetCommentsForArticle(Guid articleId);
        IList<Comment> GetCommentsForArticle(Article article);
        void Add(Guid articleId, string commentName, string commentEmail, string commentHeader, string commentText);
    }
}

