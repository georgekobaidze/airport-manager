using AirportManager.API.DTOs;
using AirportManager.API.Entities;
using AirportManager.API.Shared;
using Microsoft.AspNetCore.JsonPatch;

namespace AirportManager.API.Services.Interfaces;

public interface IAirportService
{
    Task<Result<IEnumerable<AirportDto>>> GetAllAsync();
    Task<Result<AirportDto>> GetByIdAsync(int id);
    Task<int> CreateAsync(CreateAirportDto createAirportDto);
    Task UpdateAsync(int id, UpdateAirportDto updateAirportDto);
    Task PartiallyUpdateAsync(int id, JsonPatchDocument<UpdateAirportDto> jsonPatchDocument);
}
