using System.ComponentModel.DataAnnotations;

namespace AirportManager.API.Dtos.Countries.Requests;

public class CreateCountryRequest
{
    [Required]
    public string Name { get; set; }
}