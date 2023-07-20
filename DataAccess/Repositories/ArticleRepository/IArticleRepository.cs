﻿using BussinessObject.Models;
using DataAccess.Infrastructure;

namespace DataAccess.ArticleRepository
{
	public interface IArticleRepository : IGenericRepository<Article>
    {
        IList<Article> GetLatestArticle(int size);

        IList<Article> GetMostViewedArticles(int size);

        Article GetArticleDetails(Guid articleId);

        void ChangePublish(Guid id);
    }
}