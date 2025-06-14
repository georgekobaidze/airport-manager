using AirportManager.API.DTOs;
using AirportManager.API.Repositories.Interfaces;
using AirportManager.API.Services.Interfaces;
using AirportManager.API.Shared;
using Microsoft.AspNetCore.JsonPatch;

namespace AirportManager.API.Services.Implementations;

public class AirportService : IAirportService
{
    private readonly IAirportRepository _airportRepository;

    public AirportService(IAirportRepository airportRepository)
    {
        _airportRepository = airportRepository;
    }

    public async Task<Result<IEnumerable<AirportDto>>> GetAllAsync()
    {
        var airportsFromDb = await _airportRepository.GetAllAsync();

        var airports = airportsFromDb.Select(airport => new AirportDto
        {
            Id = airport.Id,
            Name = airport.Name,
            CountryId = airport.CountryId
        });

        return Result<IEnumerable<AirportDto>>.Ok(airports);
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