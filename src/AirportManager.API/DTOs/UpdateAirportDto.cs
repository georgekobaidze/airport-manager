using System.ComponentModel.DataAnnotations;

public class UpdateAirportDto
{
    [Required]
    public string Name { get; set; }

    public int CountryId { get; set; }
}