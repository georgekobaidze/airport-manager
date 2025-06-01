using AirportManager.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AirportManager.API.Controllers;

[ApiController]
[Route("api/airports")]
public class AirportsController : ControllerBase
{
    [HttpGet]
    public ActionResult<ICollection<AirportDto>> GetAirports()
    {
        var airports = DummyDataProvider.GetAirports();

        return Ok(airports);
    }

    [HttpGet("{id}", Name = "GetAirport")]
    public ActionResult<AirportDto> GetAirport(int id)
    {
        var airport = DummyDataProvider.GetAirport(id);

        if (airport == null)
            return NotFound();

        return Ok(airport);
    }

    [HttpPost]
    public ActionResult CreateAirport(CreateAirportDto createAirportDto)
    {
        var airportId = DummyDataProvider.CreateAirport(createAirportDto);
        if (airportId != -1)
            return CreatedAtRoute(
                "GetAirport",
                new { id = airportId },
                new AirportDto
                {
                    Id = airportId,
                    CountryId = createAirportDto.CountryId,
                    Name = createAirportDto.Name
                });

        return StatusCode(StatusCodes.Status500InternalServerError);
    }
}