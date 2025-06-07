using System.ComponentModel.DataAnnotations;

namespace AirportManager.API.DTOs;

public class UpdateCountryDto
{
    [Required]
    public string Name { get; set; }

    public int NumberOfAirports { get; set; }
}