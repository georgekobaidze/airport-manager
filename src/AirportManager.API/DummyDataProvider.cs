namespace AirportManager.API;

public class DummyDataProvider
{
    private readonly List<CountryDto> _countries;

    public static DummyDataProvider Countries { get; } = new DummyDataProvider();

    public List<CountryDto> GetCountries()
    {
        return _countries;
    }
    
    public DummyDataProvider()
    {
        _countries = new List<CountryDto>
        {
            new CountryDto
            {
                Id = 1,
                Name = "United States",
                NumberOfAirports = 13500
           },
            new CountryDto
            {
                Id = 2,
                Name = "United Kingdom",
                NumberOfAirports = 471
            },
            new CountryDto
            {
                Id = 3,
                Name = "Australia",
                NumberOfAirports = 600
            }
        };
    }

}