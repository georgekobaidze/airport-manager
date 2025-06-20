using System.ComponentModel.DataAnnotations;

namespace AirportManager.API.DTOs;

public class UpdateAirportDto
{
    [Required]
    public string Name { get; set; }

    public string? Description { get; set; }

    public int? CountryId { get; set; }
}