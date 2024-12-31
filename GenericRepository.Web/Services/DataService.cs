using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Web.Services;

public class DataService<T> : IDataService<T> where T : class
{
    private readonly DbContext _dbContext;
    public DataService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<IEnumerable<T>> GetAllAsync()
    {
        return Task.FromResult(_dbContext.Set<T>().AsEnumerable());
    }
}