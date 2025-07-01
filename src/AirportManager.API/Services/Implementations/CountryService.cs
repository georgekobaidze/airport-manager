using System.Net;
using AirportManager.API.Common;
using AirportManager.API.DTOs;
using AirportManager.API.Entities;
using AirportManager.API.Repositories.Interfaces;
using AirportManager.API.Services.Interfaces;
using AirportManager.API.Shared;
using Microsoft.AspNetCore.JsonPatch;

namespace AirportManager.API.Services.Implementations;

public class CountryService : ICountryService
{
    private readonly ICountryRepository _countryRepository;

    public CountryService(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<Result<IEnumerable<CountryDto>>> GetAllAsync(PagingOptions pagingOptions)
    {
        var countriesFromDb = await _countryRepository.GetAllAsync(pagingOptions);

        var countries = countriesFromDb.Select(country => new CountryDto
        {
            Id = country.Id,
            Name = country.Name,
            NumberOfAirports = country.Airports.Count,
            TopAirports = country.Airports.Select(airport => new AirportDto
            {
                Id = airport.Id,
                CountryId = airport.CountryId,
                Name = airport.Name,
                Description = airport.Description
            })
        });

        return Result<IEnumerable<CountryDto>>.Ok(countries);
    }

    public async Task<Result<CountryDto>> GetByPkAsync(int id)
    {
        var countryFromDb = await _countryRepository.GetByPkAsync(id);

        if (countryFromDb == null)
            return Result<CountryDto>.FailNotFound();

        var country = new CountryDto
        {
            Id = countryFromDb.Id,
            Name = countryFromDb.Name,
            NumberOfAirports = countryFromDb.Airports.Count,
            TopAirports = countryFromDb.Airports.Select(airport => new AirportDto
            {
                Id = airport.Id,
                CountryId = airport.CountryId,
                Name = airport.Name,
                Description = airport.Description
            })
        };

        return Result<CountryDto>.Ok(country);
    }

    public async Task<Result<int>> CreateAsync(CreateCountryDto createCountryDto)
    {
        var countryEntity = new Country
        {
            Name = createCountryDto.Name
        };

        var countryId = await _countryRepository.CreateAsync(countryEntity);

        if (countryId < 1)
            return Result<int>.Fail("Resource couldn't be created.");

        return Result<int>.Ok(countryId);
    }

    public async Task<Result> UpdateAsync(int id, UpdateCountryDto updateCountryDto)
    {
        var countryEntity = new Country
        {
            Id = id,
            Name = updateCountryDto.Name
        };

        var updateResult = await _countryRepository.UpdateAsync(countryEntity);
        if (updateResult < 1)
            return Result.FailNotFound();

        return Result.Ok().WithStatus((int)HttpStatusCode.NoContent);
    }

    public async Task<Result> PartiallyUpdateAsync(int id, JsonPatchDocument<UpdateCountryDto> jsonPatchDocument)
    {
        var countryEntity = await _countryRepository.GetByPkAsync(id);

        if (countryEntity == null)
            return Result.FailNotFound();

        var countryToPatch = new UpdateCountryDto
        {
            Name = countryEntity.Name
        };

        try
        {
            jsonPatchDocument.ApplyTo(countryToPatch);
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message, (int)StatusCodes.Status400BadRequest);
        }

        // TODO: add validation when you add fluent validations.

        countryEntity.Name = countryToPatch.Name;

        await _countryRepository.UpdateAsync(countryEntity);

        return Result.Ok().WithStatus((int)HttpStatusCode.NoContent);
    }

    public async Task<Result> DeleteAsync(int id)
    {
        var deleteResult = await _countryRepository.DeleteAsync(id);
        if (deleteResult < 1)
            return Result.FailNotFound();

        return Result.Ok().WithStatus((int)HttpStatusCode.NoContent);
    }
}