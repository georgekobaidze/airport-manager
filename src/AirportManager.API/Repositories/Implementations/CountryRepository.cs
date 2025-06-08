using AirportManager.API.Entities;
using AirportManager.API.Repositories.Interfaces;

namespace AirportManager.API.Repositories.Implementations;

public class CountryRepository : GenericRepository<Country>, ICountryRepository
{
}