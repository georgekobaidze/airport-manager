namespace AirportManager.API.Entities;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Airport> Airports { get; set; } = [];
}