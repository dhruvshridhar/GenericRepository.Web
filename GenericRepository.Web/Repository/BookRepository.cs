using GenericRepository.Web.Database;
using GenericRepository.Web.Entities;

namespace GenericRepository.Web.Repository
{
    public class BookRepository : GenericRepository<Book>, IGenericRepository<Book>
	{
		public BookRepository(AppDbContext dbContext) : base(dbContext)
		{
		}
	}
}

