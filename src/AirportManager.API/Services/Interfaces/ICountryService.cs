using AirportManager.API.Common;
using AirportManager.API.DTOs;
using AirportManager.API.Shared;
using Microsoft.AspNetCore.JsonPatch;

namespace AirportManager.API.Services.Interfaces;

public interface ICountryService
{
    Task<Result<IEnumerable<CountryDto>>> GetAllAsync(PagingOptions pagingOptions);
    Task<Result<CountryDto>> GetByPkAsync(int id);
    Task<Result<int>> CreateAsync(CreateCountryDto createCountryDto);
    Task<Result> UpdateAsync(int id, UpdateCountryDto updateCountryDto);
    Task<Result> PartiallyUpdateAsync(int id, JsonPatchDocument<UpdateCountryDto> jsonPatchDocument);
    Task<Result> DeleteAsync(int id);
}