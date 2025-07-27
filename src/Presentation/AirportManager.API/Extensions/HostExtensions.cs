using AirportManager.API.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AirportManager.API.Extensions;

public static class HostExtensions
{
    public static IHost SeedDatabase(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<AirportManagerDbContext>();
            context.Database.Migrate();

            if (!context.Countries.Any())
            {
                var countries = SeedData.GetCountries();
                context.Countries.AddRange(countries);
            }

            if (!context.Airports.Any())
            {
                var airports = SeedData.GetAirports();
                context.Airports.AddRange(airports);
            }

            context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error seeding database: {ex.Message}");
        }

        return host;
    }
}