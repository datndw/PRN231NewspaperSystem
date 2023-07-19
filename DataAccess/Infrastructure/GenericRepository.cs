using DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Infrastructure
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly NewspaperDbContext _db;
        protected readonly DbSet<TEntity> _dbSet;
        public GenericRepository(NewspaperDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }
        public IList<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }
        public TEntity Find(Guid id)
        {
            return _dbSet.Find(id);
        }
        public TEntity FindByCondition(Func<TEntity, bool> condition)
        {
            return _dbSet.First(condition);
        }
        public IList<TEntity> GetByCondition(Func<TEntity, bool> condition)
        {
            return _dbSet.Where(condition).ToList();
        }
        public void Insert(TEntity obj)
        {
            _dbSet.Add(obj);
        }
        public void Update(TEntity obj)
        {
            _dbSet.Update(obj);
        }
        public void Delete(TEntity obj)
        {
            _dbSet.Remove(obj);
        }

        public void DeleteById(Guid id)
        {
            var obj = _dbSet.Find(id);
            if (obj != null)
            {
                _dbSet.Remove(obj);
            }
        }

        public IList<TEntity> GetPagedItems(int page, int pageSize)
        {
            return _dbSet.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public int CountAll()
        {
            return _dbSet.Count();
        }
    }
}

