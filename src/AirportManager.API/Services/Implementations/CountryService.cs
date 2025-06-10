using AirportManager.API.DTOs;
using AirportManager.API.Entities;
using AirportManager.API.Services.Interfaces;

namespace AirportManager.API.Services.Implementations;

public class CountryService : ICountryService
{
    public Task<int> CreateAsync(CreateCountryDto createCountryDto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CountryDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CountryDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, UpdateCountryDto updateCountryDto)
    {
        throw new NotImplementedException();
    }
}