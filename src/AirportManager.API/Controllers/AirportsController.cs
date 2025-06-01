using AirportManager.API.DTOs;
using Microsoft.AspNetCore.JsonPatch;
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

    [HttpPut("{id}")]
    public ActionResult UpdateAirport(int id, UpdateAirportDto updateAirportDto)
    {
        var airportToUpdate = DummyDataProvider.GetAirports().FirstOrDefault(x => x.Id == id);
        if (airportToUpdate == null)
            return NotFound();

        airportToUpdate.Name = updateAirportDto.Name;
        airportToUpdate.CountryId = updateAirportDto.CountryId;

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult PartiallyUpdateAirport(int id, JsonPatchDocument<UpdateAirportDto> jsonPatchDocument)
    {
        var airportFromStore = DummyDataProvider.GetAirports().FirstOrDefault(x => x.Id == id);
        if (airportFromStore == null)
            return NotFound();

        var airportToPatch = new UpdateAirportDto
        {
            Name = airportFromStore.Name,
            CountryId = airportFromStore.CountryId
        };

        jsonPatchDocument.ApplyTo(airportToPatch, ModelState);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!TryValidateModel(airportToPatch))
            return BadRequest(ModelState);

        airportFromStore.CountryId = airportToPatch.CountryId;
        airportFromStore.Name = airportToPatch.Name;

        return NoContent();
    }
}