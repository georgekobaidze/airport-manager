using AirportManager.API.DbConnectionFactory.Interfaces;
using AirportManager.API.Entities;
using AirportManager.API.Repositories.Interfaces;

namespace AirportManager.API.Repositories.Implementations;

public class AirportRepository : GenericRepository<Airport>, IAirportRepository
{
    public AirportRepository(IDbConnectionFactory dbConnection)
        : base (dbConnection)
    {
    }
}