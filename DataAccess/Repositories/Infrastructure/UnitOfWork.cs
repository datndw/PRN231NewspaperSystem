using DataAccess.ArticleRepository;
using DataAccess.CategoryRepository;
using DataAccess.CommentRepository;
using DataAccess.DbContexts;
using DataAccess.RoleRepository;
using DataAccess.UserRepository;

namespace DataAccess.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposed = false;
        private readonly NewspaperDbContext _db;

        private ICategoryRepository _categoryRepository;

        private ICommentRepository _commentRepository;

        private IArticleRepository _articleRepository;

        private IRoleRepository _roleRepository;

        private IUserRepository _userRepository;

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository.CategoryRepository(_db);
                return _categoryRepository;
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                    _commentRepository = new CommentRepository.CommentRepository(_db);
                return _commentRepository;
            }
        }

        public IArticleRepository ArticleRepository
        {
            get
            {
                if (_articleRepository == null)
                    _articleRepository = new ArticleRepository.ArticleRepository(_db);
                return _articleRepository;
            }
        }

        public IRoleRepository RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                    _roleRepository = new RoleRepository.RoleRepository(_db);
                return _roleRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository.UserRepository(_db);
                return _userRepository;
            }
        }


        public UnitOfWork(NewspaperDbContext db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

