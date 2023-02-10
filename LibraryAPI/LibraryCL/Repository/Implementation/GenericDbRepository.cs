using LibraryCL.Model;
using Microsoft.EntityFrameworkCore;
using System;
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
            await Save();
            return entity;
        }


        public async Task<T> Update(T entity)
        {
            _libraryDbContext.Set<T>().Update(entity);
            await Save();
            return entity;
        }

        public async Task<T?> GetById(int id)
        {
            return await _libraryDbContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return _libraryDbContext.Set<T>();
        }

        public async Task Delete(int id)
        {
            T? entity = await _libraryDbContext.Set<T>().FindAsync(id);
            if (entity == null) return;
            _libraryDbContext.Set<T>().Remove(entity);
            await Save();
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> expression)
        {
            return _libraryDbContext.Set<T>().Where(expression);
        }

        private async Task Save()
        {
            await _libraryDbContext.SaveChangesAsync();
        }
    }
}
