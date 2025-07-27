using AirportManager.API.Common;
using AirportManager.API.Dtos.Countries.Requests;
using AirportManager.API.Dtos.Countries.Responses;
using AirportManager.API.Shared;
using Microsoft.AspNetCore.JsonPatch;

namespace AirportManager.API.Services.Interfaces;

public interface ICountryService
{
    Task<PaginatedResult<IEnumerable<CountryResponse>>> GetAllAsync(PagingOptions pagingOptions);
    Task<Result<CountryResponse>> GetByPkAsync(int id);
    Task<Result<int>> CreateAsync(CreateCountryRequest createCountryDto);
    Task<Result> UpdateAsync(int id, UpdateCountryRequest updateCountryDto);
    Task<Result> PartiallyUpdateAsync(int id, JsonPatchDocument<UpdateCountryRequest> jsonPatchDocument);
    Task<Result> DeleteAsync(int id);
}