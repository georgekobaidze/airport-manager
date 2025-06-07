using AirportManager.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirportManager.API.DbContexts;

public class AirportManagerDbContext : DbContext
{
    public AirportManagerDbContext(DbContextOptions<AirportManagerDbContext> options)
        : base(options)
    {
    }

    public DbSet<Country> Countries { get; set; }
    public DbSet<Airport> Airports { get; set; }
}