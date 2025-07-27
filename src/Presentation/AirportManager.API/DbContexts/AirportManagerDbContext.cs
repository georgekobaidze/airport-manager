using AirportManager.API.Entities;
using AirportManager.API.Entities.EntityConfigurations;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AirportConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
    }
}