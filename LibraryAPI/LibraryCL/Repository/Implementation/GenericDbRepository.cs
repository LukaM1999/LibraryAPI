using LibraryCL.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryCL.Repository.Implementation
{

    public class GenericDbRepository<T> : IGenericDbRepository<T> where T : EntityBase
    {
        private readonly DbContext _libraryDbContext;

        public GenericDbRepository(DbContext libraryDbCOntext)
        {
            _libraryDbContext = libraryDbCOntext;
        }

        public async Task<T> Create(T entity)
        {
            await _libraryDbContext.Set<T>().AddAsync(entity);
            return entity;
        }


        public T Update(T entity)
        {
            _libraryDbContext.Set<T>().Update(entity);
            return entity;
        }

        public async Task<T?> GetById(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> entities = _libraryDbContext.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    entities = entities.Include(include);
                }
            }
            return await entities.FirstOrDefaultAsync(e => e.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return _libraryDbContext.Set<T>();
        }

        public void Delete(T entity)
        {
            entity.Deleted = true;
            _libraryDbContext.Set<T>().Update(entity);
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> expression)
        {
            return _libraryDbContext.Set<T>().Where(expression);
        }
    }
}
