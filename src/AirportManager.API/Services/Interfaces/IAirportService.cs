using AirportManager.API.DTOs;
using AirportManager.API.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace AirportManager.API.Services.Interfaces;

public interface IAirportService
{
    Task<int> CreateAsync(CreateAirportDto createAirportDto);
    Task<IEnumerable<AirportDto>> GetAllAsync();
    Task<AirportDto> GetByIdAsync(int id);
    Task UpdateAsync(int id, UpdateAirportDto updateAirportDto);
    Task PartiallyUpdateAsync(int id, JsonPatchDocument<UpdateAirportDto> jsonPatchDocument);
}
