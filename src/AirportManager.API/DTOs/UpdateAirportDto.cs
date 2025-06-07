using System.ComponentModel.DataAnnotations;

namespace AirportManager.API.DTOs;

public class UpdateAirportDto
{
    [Required]
    public string Name { get; set; }

    public int CountryId { get; set; }
}