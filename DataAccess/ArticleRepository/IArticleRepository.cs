using BussinessObject.Models;
using DataAccess.Infrastructure;

namespace DataAccess.ArticleRepository
{
	public interface IArticleRepository : IGenericRepository<Article>
    {
        IList<Article> GetLatestArticle(int size);

        IList<Article> GetArticlesByCategory(string category);

        IList<Article> GetMostViewedArticles(int size);

        Article GetDetails(int year, int month, string urlSlug);

        void ChangePublish(Guid id);
    }
}