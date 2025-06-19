using System.Net;
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

    public async Task<Result<AirportDto>> GetByPkAsync(int id)
    {
        var airportFromDb = await _airportRepository.GetByPkAsync(id);

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

    public async Task<Result<int>> CreateAsync(CreateAirportDto createAirportDto)
    {
        var airportEntity = new Airport
        {
            Name = createAirportDto.Name,
            CountryId = createAirportDto.CountryId,
            Description = createAirportDto.Description
        };

        var airportId = await _airportRepository.CreateAsync(airportEntity);

        if (airportId < 1)
            return Result<int>.Fail("Resource couldn't be created.");

        return Result<int>.Ok(airportId);
    }

    public async Task<Result> UpdateAsync(int id, UpdateAirportDto updateAirportDto)
    {
        var airportEntity = new Airport
        {
            Id = id,
            CountryId = updateAirportDto.CountryId,
            Name = updateAirportDto.Name,
            Description = updateAirportDto.Description
        };

        var updateResult = await _airportRepository.UpdateAsync(airportEntity);
        if (updateResult < 1)
            return Result.FailNotFound();

        return Result.Ok().WithStatus((int)HttpStatusCode.NoContent);
    }


    public Task PartiallyUpdateAsync(int id, JsonPatchDocument<UpdateAirportDto> jsonPatchDocument)
    {
        throw new NotImplementedException();
    }

}