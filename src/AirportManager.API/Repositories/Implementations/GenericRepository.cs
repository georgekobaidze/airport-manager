using AirportManager.API.DbConnectionFactory.Interfaces;
using AirportManager.API.Helpers;
using AirportManager.API.Repositories.Interfaces;
using Dapper;

namespace AirportManager.API.Repositories.Implementations;

public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly IDbConnectionFactory _factory;
    private readonly string _tableName = typeof(T).Name.PascalCaseToSnakeCase().Pluralize();

    public GenericRepository(IDbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var query = $"SELECT * FROM {_tableName}";

        var connection = _factory.CreateConnection();

        return await connection.QueryAsync<T>(query);
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var query = $"SELECT * FROM {_tableName} WHERE id = @id LIMIT 1";

        var connection = _factory.CreateConnection();

        return await connection.QueryFirstOrDefaultAsync<T>(query, id);

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