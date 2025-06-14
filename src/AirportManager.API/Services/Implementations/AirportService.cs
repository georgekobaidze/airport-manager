using AirportManager.API.DTOs;
using AirportManager.API.Entities;
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

    public async Task<Result<AirportDto>> GetByIdAsync(int id)
    {
        var airportFromDb = await _airportRepository.GetByIdAsync(id);

        if (airportFromDb == null)
            return Result<AirportDto>.FailNotFound();

        var airport = new AirportDto
        {
            Id = airportFromDb.Id,
            Name = airportFromDb.Name,
            CountryId = airportFromDb.CountryId
        };

        return Result<AirportDto>.Ok(airport);
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