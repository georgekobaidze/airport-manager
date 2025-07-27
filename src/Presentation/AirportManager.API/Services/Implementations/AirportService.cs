using System.Net;
using AirportManager.API.Common;
using AirportManager.API.Dtos.Airports.Requests;
using AirportManager.API.Dtos.Airports.Responses;
using AirportManager.API.Entities;
using AirportManager.API.Repositories.Interfaces;
using AirportManager.API.Services.Interfaces;
using AirportManager.API.Shared;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Exceptions;

namespace AirportManager.API.Services.Implementations;

public class AirportService : IAirportService
{
    private readonly IAirportRepository _airportRepository;

    public AirportService(IAirportRepository airportRepository)
    {
        _airportRepository = airportRepository;
    }

    public async Task<PaginatedResult<IEnumerable<AirportResponse>>> GetAllAsync(PagingOptions pagingOptions)
    {
        var airportsFromDb = await _airportRepository.GetAllAsync(pagingOptions);

        var airports = airportsFromDb.Item1.Select(airport => new AirportResponse
        {
            Id = airport.Id,
            Name = airport.Name,
            CountryId = airport.CountryId
        });

        return PaginatedResult<IEnumerable<AirportResponse>>.Ok(
            airports,
            new PaginationMetadata(airportsFromDb.Item2, pagingOptions.PageSize, pagingOptions.Page));
    }

    public async Task<Result<AirportResponse>> GetByPkAsync(int id)
    {
        var airportFromDb = await _airportRepository.GetByPkAsync(id);

        if (airportFromDb == null)
            return Result<AirportResponse>.FailNotFound();

        var airport = new AirportResponse
        {
            Id = airportFromDb.Id,
            Name = airportFromDb.Name,
            CountryId = airportFromDb.CountryId
        };

        return Result<AirportResponse>.Ok(airport);
    }

    public async Task<Result<int>> CreateAsync(CreateAirportRequest createAirportDto)
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

    public async Task<Result> UpdateAsync(int id, UpdateAirportRequest updateAirportDto)
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


    public async Task<Result> PartiallyUpdateAsync(int id, JsonPatchDocument<UpdateAirportRequest> jsonPatchDocument)
    {
        var airportEntity = await _airportRepository.GetByPkAsync(id);

        if (airportEntity == null)
            return Result.FailNotFound();

        var airportToPatch = new UpdateAirportRequest
        {
            Name = airportEntity.Name,
            CountryId = airportEntity.CountryId,
            Description = airportEntity.Description
        };

        try
        {
            jsonPatchDocument.ApplyTo(airportToPatch);
        }
        catch (JsonPatchException ex)
        {
            return Result.Fail(ex.Message, (int)StatusCodes.Status400BadRequest);
        }

        // TODO: add validation when you add fluent validations.

        airportEntity.Name = airportToPatch.Name;
        airportEntity.CountryId = airportToPatch.CountryId;
        airportEntity.Description = airportToPatch.Description;

        await _airportRepository.UpdateAsync(airportEntity);

        return Result.Ok().WithStatus((int)HttpStatusCode.NoContent);
    }

    public async Task<Result> DeleteAsync(int id)
    {
        var deleteResult = await _airportRepository.DeleteAsync(id);
        if (deleteResult < 1)
            return Result.FailNotFound();

        return Result.Ok().WithStatus((int)HttpStatusCode.NoContent);
    }
}