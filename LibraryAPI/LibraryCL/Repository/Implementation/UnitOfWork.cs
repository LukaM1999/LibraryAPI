using LibraryCL.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryCL.Repository.Implementation
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext) { 
            _dbContext = dbContext;
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
