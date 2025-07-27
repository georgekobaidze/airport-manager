using AirportManager.API.DbConnectionFactory.Interfaces;
using AirportManager.API.Entities;
using AirportManager.API.Repositories.Interfaces;

namespace AirportManager.API.Repositories.Implementations;

public class CountryRepository : GenericRepository<Country>, ICountryRepository
{
    public CountryRepository(IDbConnectionFactory dbConnection)
        : base(dbConnection)
    {
    }
}