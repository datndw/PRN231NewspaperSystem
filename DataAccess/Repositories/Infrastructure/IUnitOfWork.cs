using DataAccess.ArticleRepository;
using DataAccess.CategoryRepository;
using DataAccess.CommentRepository;
using DataAccess.RoleRepository;
using DataAccess.UserRepository;

namespace DataAccess.Infrastructure
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }
        public ICommentRepository CommentRepository { get; }
        public IArticleRepository ArticleRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IUserRepository UserRepository { get; }

        Task<int> SaveAsync();
    }
}

