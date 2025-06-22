using AirportManager.API.DTOs;
using AirportManager.API.Entities;
using AirportManager.API.Shared;
using Microsoft.AspNetCore.JsonPatch;

namespace AirportManager.API.Services.Interfaces;

public interface ICountryService
{
    Task<Result<IEnumerable<CountryDto>>> GetAllAsync();
    Task<int> CreateAsync(CreateCountryDto createCountryDto);
    Task<CountryDto> GetByIdAsync(int id);
    Task UpdateAsync(int id, UpdateCountryDto updateCountryDto);
    Task PartiallyUpdateAsync(int id, JsonPatchDocument<UpdateCountryDto> jsonPatchDocument);
}