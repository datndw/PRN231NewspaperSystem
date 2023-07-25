using BussinessObject.Models;
using DataAccess.Infrastructure;

namespace DataAccess.ArticleRepository
{
	public interface IArticleRepository : IGenericRepository<Article>
    {
        IList<Article> GetLatestArticle(int size);

        IList<Article> GetMostViewedArticles(int size);

        Article GetArticleDetails(Guid articleId);

        IList<Article> GetArticlesByCategory(Guid categoryId);

        void ChangePublish(Guid id);

        IList<Article> GetByKeyword(string keyword);
    }
}