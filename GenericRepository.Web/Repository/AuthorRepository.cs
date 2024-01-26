using GenericRepository.Web.Database;
using GenericRepository.Web.Entities;

namespace GenericRepository.Web.Repository
{
    public class AuthorRepository : GenericRepository<Author>, IGenericRepository<Author>
	{
		public AuthorRepository(AppDbContext dbContext) : base(dbContext)
		{
		}
	}
}

