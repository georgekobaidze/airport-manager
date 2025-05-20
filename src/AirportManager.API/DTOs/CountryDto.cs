namespace AirportManager.API.DTOs;

public class CountryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int NumberOfAirports { get; set; }
    
    public ICollection<AirportDto> TopAirports { get; set; }
}