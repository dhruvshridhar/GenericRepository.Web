using GenericRepository.Web.Database;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Web.Services;

public class PostgresDataService<T> : IDataService<T> where T : class
{
    private readonly PostgresDbContext _dbContext;
    public PostgresDataService(PostgresDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<IEnumerable<T>> GetAllAsync()
    {
        return Task.FromResult(_dbContext.Set<T>().AsEnumerable());
    }
}