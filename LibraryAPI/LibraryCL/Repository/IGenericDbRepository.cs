using LibraryCL.Model;
using System.Linq.Expressions;

namespace LibraryCL.Repository
{

	public interface IGenericDbRepository<T> where T : EntityBase
	{
		Task<T> Create(T entity);
		T Update(T entity);
		Task<T?> GetById(int id, params Expression<Func<T, object>>[] includes);
		IQueryable<T> GetAll();
		void Delete(T entity);
		IQueryable<T> Search(Expression<Func<T, bool>> exp);
	}
}