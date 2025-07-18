using System.Reflection;
using AirportManager.API.DbConnectionFactory.Implementations;
using AirportManager.API.DbConnectionFactory.Interfaces;
using AirportManager.API.DbContexts;
using AirportManager.API.Extensions;
using AirportManager.API.Repositories.Implementations;
using AirportManager.API.Repositories.Interfaces;
using AirportManager.API.Services.Implementations;
using AirportManager.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AirportManagerDbContext>(
    options => options.UseSqlite(connectionString));

builder.Services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();

builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IAirportRepository, AirportRepository>();

builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IAirportService, AirportService>();

builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.SeedDatabase();

app.Run();