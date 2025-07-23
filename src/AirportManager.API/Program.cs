using System.Reflection;
using AirportManager.API.DbConnectionFactory.Implementations;
using AirportManager.API.DbConnectionFactory.Interfaces;
using AirportManager.API.DbContexts;
using AirportManager.API.Extensions;
using AirportManager.API.Repositories.Implementations;
using AirportManager.API.Repositories.Interfaces;
using AirportManager.API.Services.Implementations;
using AirportManager.API.Services.Interfaces;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddEndpointsApiExplorer();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AirportManagerDbContext>(
    options => options.UseSqlite(connectionString));

builder.Services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();

builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IAirportRepository, AirportRepository>();

builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IAirportService, AirportService>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(builder.Configuration["Authentication:Secret"]))
        };
    });

builder.Services.AddApiVersioning(setupAction =>
{
    setupAction.ReportApiVersions = true;
    setupAction.AssumeDefaultVersionWhenUnspecified = true;
    setupAction.DefaultApiVersion = new ApiVersion(1, 0);
}).AddMvc().AddApiExplorer(options =>
{
    options.SubstituteApiVersionInUrl = true;
});

var apiVersionDescriptionProvider = builder.Services.BuildServiceProvider()
    .GetRequiredService<IApiVersionDescriptionProvider>();

builder.Services.AddSwaggerGen(c =>
{
    foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
    {
        c.SwaggerDoc($"{description.GroupName}", new()
        {
            Title = "Airport Manager API",
            Version = description.ApiVersion.ToString(),
            Description = "Airport manager API"
        });
    }

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var descriptions = app.DescribeApiVersions();
        foreach (var description in descriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.SeedDatabase();

app.Run();