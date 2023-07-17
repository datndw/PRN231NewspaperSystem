namespace DataAccess.Infrastructure
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
        TEntity Find(Guid id);
        TEntity FindByCondition(Func<TEntity, bool> condition);
        IList<TEntity> GetByCondition(Func<TEntity, bool> condition);
        IList<TEntity> GetPagedItems(int page, int pageSize);
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        void DeleteById(Guid id);
        int CountAll();
    }
}

