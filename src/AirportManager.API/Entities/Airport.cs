namespace AirportManager.API.Entities;

public class Airport
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int? CountryId { get; set; }

    public Country? Country { get; set; }
}