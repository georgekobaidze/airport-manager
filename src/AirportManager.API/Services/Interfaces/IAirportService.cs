using AirportManager.API.Common;
using AirportManager.API.DTOs;
using AirportManager.API.Shared;
using Microsoft.AspNetCore.JsonPatch;

namespace AirportManager.API.Services.Interfaces;

public interface IAirportService
{
    Task<PaginatedResult<IEnumerable<AirportDto>>> GetAllAsync(PagingOptions pagingOptions);
    Task<Result<AirportDto>> GetByPkAsync(int id);
    Task<Result<int>> CreateAsync(CreateAirportDto createAirportDto);
    Task<Result> UpdateAsync(int id, UpdateAirportDto updateAirportDto);
    Task<Result> PartiallyUpdateAsync(int id, JsonPatchDocument<UpdateAirportDto> jsonPatchDocument);
    Task<Result> DeleteAsync(int id);
}
