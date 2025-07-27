namespace AirportManager.API.Dtos.Airports.Responses;

public class AirportResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    
    public int? CountryId { get; set; }
}