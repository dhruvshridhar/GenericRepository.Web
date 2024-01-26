using System;
namespace GenericRepository.Web.Repository
{
	public interface IGenericRepository<T> where T : class
	{
		public IQueryable<T> GetAll();
		public ValueTask<T?> GetById(object id);
		public Task Insert(T entity);
		public Task Update(object id, T entity);
		public Task Delete(object id);
		public Task Save();
	}
}

