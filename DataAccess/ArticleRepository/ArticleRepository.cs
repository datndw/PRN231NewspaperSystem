using System;
using BussinessObject.DbContexts;
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
        public IList<Article> GetArticlesByCategory(string category)
        {
            return _db.Articles.Where(p => p.Category.UrlSlug == category).Include(p => p.Category).ToList();
        }

        public Article GetDetails(int year, int month, string urlSlug)
        {
            return _db.Articles.Include(p => p.Category).Include(p => p.Comments).First(p => p.PostedOn.Year == year && p.PostedOn.Month == month && p.UrlSlug == urlSlug);
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

