using AirportManager.API.DbConnectionFactory.Interfaces;
using AirportManager.API.Repositories.Interfaces;

namespace AirportManager.API.Repositories.Implementations;

public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly IDbConnectionFactory _dbConnection;

    public GenericRepository(IDbConnectionFactory dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public Task<T> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
    public Task<IEnumerable<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
    public Task CreateAsync(T entity)
    {
        throw new NotImplementedException();
    }
    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}