using System;
using BussinessObject.DbContexts;
using BussinessObject.Models;
using DataAccess.Infrastructure;

namespace DataAccess.CommentRepository
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(NewspaperDbContext db) : base(db) { }

        public IList<Comment> GetCommentsForArticle(Guid articleId)
        {
            var c = _db.Comments.ToList();
            return _db.Comments.Where(c => c.ArticleId == articleId).ToList();
        }
        public IList<Comment> GetCommentsForArticle(Article article)
        {
            return _db.Comments.Where(c => c.ArticleId == article.Id).ToList();
        }

        public void Add(Guid articleId, string commentName, string commentEmail, string commentHeader, string commentText)
        {
            var comment = new Comment()
            {
                ArticleId = articleId,
                Name = commentName,
                Email = commentEmail,
                CommentHeader = commentHeader,
                CommentText = commentText,
                CommentTime = DateTime.Now
            };
            _db.Comments.Add(comment);
        }
    }
}

