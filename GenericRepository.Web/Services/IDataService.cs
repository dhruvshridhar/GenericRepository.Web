namespace GenericRepository.Web.Services;

public interface IDataService<T>
{
    public Task<IEnumerable<T>> GetAllAsync();
}