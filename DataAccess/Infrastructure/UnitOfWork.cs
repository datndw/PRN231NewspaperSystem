using BussinessObject.DbContexts;

namespace DataAccess.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposed = false;
        private readonly NewspaperDbContext _db;

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

