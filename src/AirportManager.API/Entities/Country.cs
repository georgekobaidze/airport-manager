using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportManager.API.Entities;

public class Country
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public int NumberOfAirports { get { return Airports.Count; } }

    public ICollection<Airport> Airports { get; set; } = new List<Airport>();
}