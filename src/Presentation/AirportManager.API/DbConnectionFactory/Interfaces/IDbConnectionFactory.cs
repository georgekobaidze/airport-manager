using System.Data;

namespace AirportManager.API.DbConnectionFactory.Interfaces;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}