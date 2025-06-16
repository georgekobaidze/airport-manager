using System.ComponentModel.DataAnnotations;

namespace AirportManager.API.DTOs;

public class CreateAirportDto
{
    [Required]
    public string Name { get; set; }

    public int CountryId { get; set; }

    public string? Description { get; set; }
}