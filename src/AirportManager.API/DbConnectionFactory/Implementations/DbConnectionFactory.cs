using System.Data;
using AirportManager.API.DbConnectionFactory.Interfaces;
using Microsoft.Data.Sqlite;

namespace AirportManager.API.DbConnectionFactory.Implementations;

public class DbConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;

    public DbConnectionFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("The default connection string wasn't found.");
    }

    public IDbConnection CreateConnection()
    {
        return new SqliteConnection(_connectionString);
    }
}
