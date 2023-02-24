using LibraryCL.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryCL.Repository.Implementation
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private IGenericDbRepository<Author> _authorRepository;
        private IGenericDbRepository<Book> _bookRepository;


        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public IGenericDbRepository<Author> AuthorRepository
        {
            get
            {
                this._authorRepository ??= new GenericDbRepository<Author>(_dbContext);
                return _authorRepository;
            }
        }

        public IGenericDbRepository<Book> BookRepository
        {
            get
            {
                this._bookRepository ??= new GenericDbRepository<Book>(_dbContext);
                return _bookRepository;
            }
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
