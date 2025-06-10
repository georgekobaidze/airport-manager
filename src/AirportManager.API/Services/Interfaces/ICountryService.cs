using AirportManager.API.DTOs;
using AirportManager.API.Entities;

namespace AirportManager.API.Services.Interfaces;

public interface ICountryService
{
    Task<int> CreateAsync(CreateCountryDto createCountryDto);
    Task<IEnumerable<CountryDto>> GetAllAsync();
    Task<CountryDto> GetByIdAsync(int id);
    Task UpdateAsync(int id, UpdateCountryDto updateCountryDto);
}