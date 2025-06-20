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
        var airportResult = await _airportService.GetByPkAsync(id);

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

        return StatusCode(StatusCodes.Status500InternalServerError, insertionResult.Message);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAirport(int id, UpdateAirportDto updateAirportDto)
    {
        var result = await _airportService.UpdateAsync(id, updateAirportDto);

        return StatusCode(result.StatusCode, result.Message);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PartiallyUpdateAirport(int id, JsonPatchDocument<UpdateAirportDto> jsonPatchDocument)
    {
        var result = await _airportService.PartiallyUpdateAsync(id, jsonPatchDocument);

        return StatusCode(result.StatusCode, result.Message);
    }
}