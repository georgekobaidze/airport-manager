
using AirportManager.API.Common;
using AirportManager.API.Dtos.Airports.Requests;
using AirportManager.API.Dtos.Airports.Responses;
using AirportManager.API.Shared;
using Microsoft.AspNetCore.JsonPatch;

namespace AirportManager.API.Services.Interfaces;

public interface IAirportService
{
    Task<PaginatedResult<IEnumerable<AirportResponse>>> GetAllAsync(PagingOptions pagingOptions);
    Task<Result<AirportResponse>> GetByPkAsync(int id);
    Task<Result<int>> CreateAsync(CreateAirportRequest createAirportDto);
    Task<Result> UpdateAsync(int id, UpdateAirportRequest updateAirportDto);
    Task<Result> PartiallyUpdateAsync(int id, JsonPatchDocument<UpdateAirportRequest> jsonPatchDocument);
    Task<Result> DeleteAsync(int id);
}
