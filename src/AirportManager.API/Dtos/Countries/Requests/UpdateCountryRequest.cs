using System.ComponentModel.DataAnnotations;

namespace AirportManager.API.Dtos.Countries.Requests;

public class UpdateCountryRequest
{
    [Required]
    public string Name { get; set; }
}