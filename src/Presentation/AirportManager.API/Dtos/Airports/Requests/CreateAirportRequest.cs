using System.ComponentModel.DataAnnotations;

namespace AirportManager.API.Dtos.Airports.Requests;

public class CreateAirportRequest
{
    [Required]
    public string Name { get; set; }

    public int CountryId { get; set; }

    public string? Description { get; set; }
}