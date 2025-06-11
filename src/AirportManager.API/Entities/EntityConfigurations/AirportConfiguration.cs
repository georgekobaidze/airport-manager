using AirportManager.API.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportManager.API.Entities.EntityConfigurations;

public class AirportConfiguration : IEntityTypeConfiguration<Airport>
{
    public void Configure(EntityTypeBuilder<Airport> builder)
    {
        builder.ToTable(nameof(Airport).PascalCaseToSnakeCase().Pluralize());

        builder.HasKey(entity => entity.Id)
            .HasName("pk_airports_id");

        builder.Property(entity => entity.Id)
            .HasColumnName(nameof(Airport.Id).PascalCaseToSnakeCase())
            .ValueGeneratedOnAdd();

        builder.Property(entity => entity.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName(nameof(Airport.Name).PascalCaseToSnakeCase());

        builder.Property(entity => entity.Description)
            .HasMaxLength(500)
            .HasColumnName(nameof(Airport.Description).PascalCaseToSnakeCase());

        builder.Property(entity => entity.CountryId)
            .HasColumnName(nameof(Airport.CountryId).PascalCaseToSnakeCase());

        builder.HasOne(a => a.Country)
               .WithMany(c => c.Airports)
               .HasForeignKey(a => a.CountryId)
               .HasConstraintName("fk_airports_country_id")
               .OnDelete(DeleteBehavior.Restrict);
    }
}