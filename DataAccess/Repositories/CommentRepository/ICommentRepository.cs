using System;
using BussinessObject.Models;
using DataAccess.Infrastructure;

namespace DataAccess.CommentRepository
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        void Add(Guid articleId, Guid userId, string commentHeader, string commentText);
    }
}