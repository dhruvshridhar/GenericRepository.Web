using GenericRepository.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Web.Database
{
	public class PostgresDbContext : DbContext
	{
		public PostgresDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
		}

		public DbSet<Book> books { get; set; }
		public DbSet<Author> authors { get; set; }
	}
}