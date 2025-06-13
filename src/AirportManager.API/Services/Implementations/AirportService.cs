using AirportManager.API.DTOs;
using AirportManager.API.Entities;
using AirportManager.API.Repositories.Interfaces;
using AirportManager.API.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace AirportManager.API.Services.Implementations;

public class AirportService : IAirportService
{
    private readonly IAirportRepository _airportRepository;

    public AirportService(IAirportRepository airportRepository)
    {
        _airportRepository = airportRepository;
    }

    public async Task<IEnumerable<AirportDto>> GetAllAsync()
    {
        var airports = await _airportRepository.GetAllAsync();

        return airports.Select(airport => new AirportDto
        {
            Id = airport.Id,
            Name = airport.Name,
            CountryId = airport.CountryId
        });
    }

    public async Task<AirportDto> GetByIdAsync(int id)
    {
        var airport = await _airportRepository.GetByIdAsync(id);

        return new AirportDto
        {
            Id = airport.Id,
            Name = airport.Name,
            CountryId = airport.CountryId
        };
    }

    public Task<int> CreateAsync(CreateAirportDto createAirportDto)
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