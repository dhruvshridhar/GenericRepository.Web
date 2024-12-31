using GenericRepository.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Web.Database;
        public class MongoDbContext : DbContext
        {
            public MongoDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
            {
            }

            public DbSet<Book> books { get; set; }
            public DbSet<Author> authors { get; set; }
        }