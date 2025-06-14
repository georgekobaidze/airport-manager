namespace AirportManager.API.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}