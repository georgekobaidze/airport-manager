using AirportManager.API.DTOs;
using AirportManager.API.Entities;
using AirportManager.API.Shared;
using Microsoft.AspNetCore.JsonPatch;

namespace AirportManager.API.Services.Interfaces;

public interface IAirportService
{
    Task<Result<IEnumerable<AirportDto>>> GetAllAsync();
    Task<Result<AirportDto>> GetByPkAsync(int id);
    Task<Result<int>> CreateAsync(CreateAirportDto createAirportDto);
    Task<Result> UpdateAsync(int id, UpdateAirportDto updateAirportDto);
    Task<Result> PartiallyUpdateAsync(int id, JsonPatchDocument<UpdateAirportDto> jsonPatchDocument);
}
