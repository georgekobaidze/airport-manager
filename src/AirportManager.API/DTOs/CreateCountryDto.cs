using System.ComponentModel.DataAnnotations;

public class CreateCountryDto
{
    [Required]
    public string Name { get; set; }

    public int NumberOfAirports { get; set; }
}