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

    [HttpPost]
    public ActionResult CreateAirport(CreateAirportDto createAirportDto)
    {
        var result = DummyDataProvider.CreateAirport(createAirportDto);
        if (result)
            return Ok();

        return StatusCode(StatusCodes.Status500InternalServerError);
    }
}