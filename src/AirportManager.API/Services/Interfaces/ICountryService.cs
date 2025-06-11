using AirportManager.API.DTOs;
using AirportManager.API.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace AirportManager.API.Services.Interfaces;

public interface ICountryService
{
    Task<int> CreateAsync(CreateCountryDto createCountryDto);
    Task<IEnumerable<CountryDto>> GetAllAsync();
    Task<CountryDto> GetByIdAsync(int id);
    Task UpdateAsync(int id, UpdateCountryDto updateCountryDto);
    Task PartiallyUpdateAsync(int id, JsonPatchDocument<UpdateCountryDto> jsonPatchDocument);
}