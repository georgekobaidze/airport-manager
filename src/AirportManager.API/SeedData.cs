using AirportManager.API.Entities;

namespace AirportManager.API;

public static class SeedData
{
    public static IEnumerable<Country> GetCountries()
    {
        return new List<Country>
        {
            new Country { Id = 1, Name = "United States" },
            new Country { Id = 2, Name = "United Kingdom" },
            new Country { Id = 3, Name = "Australia" }
        };
    }
    public static IEnumerable<Airport> GetAirports()
    {
        return new List<Airport>
        {
            new Airport { Name = "Hartsfield–Jackson Atlanta International Airport", CountryId = 1 },
            new Airport { Name = "Los Angeles International Airport", CountryId = 1 },
            new Airport { Name = "Dallas/Fort Worth International Airport", CountryId = 1 },
            new Airport { Name = "Sydney Kingsford Smith Airport", CountryId = 3 },
            new Airport { Name = "Melbourne Airport (Tullamarine)", CountryId = 3 },
            new Airport { Name = "Brisbane Airport", CountryId = 3 },
            new Airport { Name = "Chicago O'Hare International Airport", CountryId = 1 },
            new Airport { Name = "London Heathrow Airport", CountryId = 2 },
            new Airport { Name = "London Gatwick Airport", CountryId = 2 },
            new Airport { Name = "Manchester Airport", CountryId = 2 }
        };
    }
}