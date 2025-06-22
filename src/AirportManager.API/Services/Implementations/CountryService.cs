using AirportManager.API.DTOs;
using AirportManager.API.Repositories.Interfaces;
using AirportManager.API.Services.Interfaces;
using AirportManager.API.Shared;
using Microsoft.AspNetCore.JsonPatch;

namespace AirportManager.API.Services.Implementations;

public class CountryService : ICountryService
{
    private readonly ICountryRepository _countryRepository;

    public async Task<Result<IEnumerable<CountryDto>>> GetAllAsync()
    {
        var countriesFromDb = await _countryRepository.GetAllAsync();

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

    public CountryService(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public Task<int> CreateAsync(CreateCountryDto createCountryDto)
    {
        throw new NotImplementedException();
    }


    public Task<CountryDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task PartiallyUpdateAsync(int id, JsonPatchDocument<UpdateCountryDto> jsonPatchDocument)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, UpdateCountryDto updateCountryDto)
    {
        throw new NotImplementedException();
    }
}