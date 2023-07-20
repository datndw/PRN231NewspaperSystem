using System;
using DataAccess.DbContexts;
using BussinessObject.Models;
using DataAccess.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.ArticleRepository
{
	public class ArticleRepository : GenericRepository<Article>, IArticleRepository
	{
		public ArticleRepository(NewspaperDbContext db) : base(db)
		{
		}

        public void ChangePublish(Guid id)
        {
            var article = _db.Articles.Find(id);
            article.IsPublished = !article.IsPublished;
            _db.Update(article);
        }

        public Article GetArticleDetails(Guid articleId)
        {
            return _db.Articles.Include(a => a.User).Include(a => a.Comments).ThenInclude(c => c.User).Include(a => a.ArticleCategories).ThenInclude(a => a.Category).Where(a => a.Id == articleId).First();
        }

        public IList<Article> GetLatestArticle(int size)
        {
            return _db.Articles.OrderByDescending(a => a.PostedOn).Take(size).ToList();
        }

        public IList<Article> GetMostViewedArticles(int size)
        {
            return _db.Articles.OrderByDescending(p => p.ViewCount).Take(size).ToList();
        }
    }
}

