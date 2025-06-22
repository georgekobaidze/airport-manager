namespace AirportManager.API.DTOs;

public class CountryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int NumberOfAirports { get; set; }
    
    public IEnumerable<AirportDto> TopAirports { get; set; }
}