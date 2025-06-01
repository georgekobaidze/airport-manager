using AirportManager.API.DTOs;

namespace AirportManager.API;

public static class DummyDataProvider
{
    public static List<CountryDto> GetCountries() => _countries;

    public static List<AirportDto> GetAirports() => _airports;

    public static int CreateAirport(CreateAirportDto airport)
    {
        var maxId = _airports.Max(x => x.Id);

        _airports.Add(new AirportDto
        {
            Id = maxId + 1,
            CountryId = airport.CountryId,
            Name = airport.Name
        });

        return maxId;
    }

    public static AirportDto? GetAirport(int id)
    {
        return _airports.FirstOrDefault(x => x.Id == id);
    }

    private static List<CountryDto> _countries = new()
    {
        new CountryDto { Id = 2, Name = "United Kingdom", NumberOfAirports = 471 },
        new CountryDto { Id = 1, Name = "United States", NumberOfAirports = 13500 },
        new CountryDto { Id = 3, Name = "Australia", NumberOfAirports = 600 }
    };

    private static List<AirportDto> _airports = new()
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