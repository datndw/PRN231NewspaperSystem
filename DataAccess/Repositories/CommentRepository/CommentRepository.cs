using System;
using DataAccess.DbContexts;
using BussinessObject.Models;
using DataAccess.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CommentRepository
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(NewspaperDbContext db) : base(db) { }

        public void Add(Guid articleId, Guid userId, string commentHeader, string commentText)
        {
            var comment = new Comment()
            {
                ArticleId = articleId,
                UserId = userId,
                CommentHeader = commentHeader,
                CommentText = commentText,
                CommentTime = DateTime.Now
            };
            _db.Comments.Add(comment);
        }
    }
}

