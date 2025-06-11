using AirportManager.API.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportManager.API.Entities.EntityConfigurations;

public class CountryConfigurations : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable(nameof(Country).PascalCaseToSnakeCase().Pluralize());

        builder.HasKey(entity => entity.Id)
            .HasName("pk_countries_id");

        builder.Property(entity => entity.Id)
            .HasColumnName(nameof(Country.Id).PascalCaseToSnakeCase())
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName(nameof(Country.Name).PascalCaseToSnakeCase());
    }
}