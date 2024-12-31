using GenericRepository.Web.Database;

namespace GenericRepository.Web.Services;

public class MongoDataService<T> : IDataService<T> where T : class
{
    private readonly MongoDbContext _dbContext;
    public MongoDataService(MongoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<IEnumerable<T>> GetAllAsync()
    {
        return Task.FromResult(_dbContext.Set<T>().AsEnumerable());
    }
}