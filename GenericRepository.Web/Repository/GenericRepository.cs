using System;
using GenericRepository.Web.Database;

namespace GenericRepository.Web.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly AppDbContext dbContext;
		public GenericRepository(AppDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

        public async Task Delete(object id)
        {
            var entity = await dbContext.FindAsync<T>(id);
            if(entity is not null)
                dbContext.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public ValueTask<T?> GetById(object id)
        {
            return dbContext.FindAsync<T>(id);
        }

        public async Task Insert(T entity)
        {
            await dbContext.AddAsync(entity);
        }

        public Task Save()
        {
            return dbContext.SaveChangesAsync();
        }

        public Task Update(object id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}

