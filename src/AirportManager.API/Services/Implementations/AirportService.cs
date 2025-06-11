using AirportManager.API.DTOs;
using AirportManager.API.Entities;
using AirportManager.API.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace AirportManager.API.Services.Implementations;

public class AirportService : IAirportService
{
    public Task<int> CreateAsync(CreateAirportDto createAirportDto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AirportDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AirportDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task PartiallyUpdateAsync(int id, JsonPatchDocument<UpdateAirportDto> jsonPatchDocument)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, UpdateAirportDto updateAirportDto)
    {
        throw new NotImplementedException();
    }
}