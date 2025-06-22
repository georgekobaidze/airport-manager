using System.ComponentModel.DataAnnotations;

namespace AirportManager.API.DTOs;

public class CreateCountryDto
{
    [Required]
    public string Name { get; set; }
}