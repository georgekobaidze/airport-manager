namespace AirportManager.API.DTOs;

public class AirportDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    
    public int? CountryId { get; set; }
}