using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using LibraryCL.Model;
using System;
using System.Linq.Expressions;

namespace LibraryCL.Repository
{

	public interface IGenericDbRepository<T> where T : EntityBase
	{
		Task<T> Create(T entity);
		Task<T> Update(T entity);
		Task<T?> GetById(int id);
		IQueryable<T> GetAll();
		Task Delete(int id);
		IQueryable<T> Search(Expression<Func<T, bool>> exp);
	}
}