using AirportManager.API.DTOs;
using AirportManager.API.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AirportManager.API.Controllers;

[ApiController]
[Route("api/airports")]
public class AirportsController : ControllerBase
{
    private readonly IAirportService _airportService;

    public AirportsController(IAirportService airportService)
    {
        _airportService = airportService;
    }


    [HttpGet]
    public async Task<ActionResult<ICollection<AirportDto>>> GetAirports()
    {
        var airports = await _airportService.GetAllAsync();

        return Ok(airports);
    }

    [HttpGet("{id}", Name = "GetAirport")]
    public async Task<ActionResult<AirportDto>> GetAirport(int id)
    {
        var airportResult = await _airportService.GetByIdAsync(id);

        if (!airportResult.Success)
            return StatusCode(airportResult.StatusCode, airportResult.Message);

        return Ok(airportResult.Data);
    }

    [HttpPost]
    public async Task<ActionResult> CreateAirport(CreateAirportDto createAirportDto)
    {
        var insertionResult = await _airportService.CreateAsync(createAirportDto);
        if (insertionResult.Success)
        {
            var airportId = insertionResult.Data;

            return CreatedAtRoute(
                "GetAirport",
                new { id = airportId },
                new AirportDto
                {
                    Id = airportId,
                    CountryId = createAirportDto.CountryId,
                    Name = createAirportDto.Name
                });
        }

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAirport(int id, UpdateAirportDto updateAirportDto)
    {
        await _airportService.UpdateAsync(id, updateAirportDto);

        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PartiallyUpdateAirport(int id, JsonPatchDocument<UpdateAirportDto> jsonPatchDocument)
    {
        // var airportFromStore = DummyDataProvider.GetAirports().FirstOrDefault(x => x.Id == id);
        // if (airportFromStore == null)
        //     return NotFound();

        // var airportToPatch = new UpdateAirportDto
        // {
        //     Name = airportFromStore.Name,
        //     CountryId = airportFromStore.CountryId
        // };

        // jsonPatchDocument.ApplyTo(airportToPatch, ModelState);

        // if (!ModelState.IsValid)
        //     return BadRequest(ModelState);

        // if (!TryValidateModel(airportToPatch))
        //     return BadRequest(ModelState);

        // airportFromStore.CountryId = airportToPatch.CountryId;
        // airportFromStore.Name = airportToPatch.Name;

        // return NoContent();

        await _airportService.PartiallyUpdateAsync(id, jsonPatchDocument);

        return NoContent();
    }
}