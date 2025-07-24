using AirportManager.API.Dtos.Airports.Responses;

namespace AirportManager.API.Dtos.Countries.Responses;

public class CountryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int NumberOfAirports { get; set; }
    
    public IEnumerable<AirportResponse> TopAirports { get; set; }
}