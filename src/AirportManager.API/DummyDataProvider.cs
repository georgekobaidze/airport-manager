using AirportManager.API.DTOs;

namespace AirportManager.API;

public static class DummyDataProvider
{
    public static List<CountryDto> GetCountries() => new()
    {
        new CountryDto { Id = 1, Name = "United States", NumberOfAirports = 13500 },
        new CountryDto { Id = 2, Name = "United Kingdom", NumberOfAirports = 471 },
        new CountryDto { Id = 3, Name = "Australia", NumberOfAirports = 600 }
    };

    public static List<AirportDto> GetAirports() => new()
    {
        new AirportDto { Id = 1, Name = "Hartsfield–Jackson Atlanta International Airport", CountryId = 1 },
        new AirportDto { Id = 2, Name = "Los Angeles International Airport", CountryId = 1 },
        new AirportDto { Id = 3, Name = "Dallas/Fort Worth International Airport", CountryId = 1 },
        new AirportDto { Id = 4, Name = "Sydney Kingsford Smith Airport", CountryId = 3 },
        new AirportDto { Id = 5, Name = "Melbourne Airport (Tullamarine)", CountryId = 3 },
        new AirportDto { Id = 6, Name = "Brisbane Airport", CountryId = 3 },
        new AirportDto { Id = 7, Name = "Chicago O'Hare International Airport", CountryId = 1 },
        new AirportDto { Id = 8, Name = "London Heathrow Airport", CountryId = 2 },
        new AirportDto { Id = 9, Name = "London Gatwick Airport", CountryId = 2 },
        new AirportDto { Id = 10, Name = "Manchester Airport", CountryId = 2 }
    };
}