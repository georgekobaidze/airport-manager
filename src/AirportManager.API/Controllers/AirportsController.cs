using AirportManager.API.Common;
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

    /// <summary>
    /// Gets all airports without a filter
    /// </summary>
    /// <returns>Airports with a status code</returns>
    [HttpGet]
    public async Task<ActionResult<ICollection<AirportDto>>> GetAirports([FromQuery] PagingOptions pagingOptions)
    {
        var airports = await _airportService.GetAllAsync(pagingOptions);

        return Ok(airports);
    }

    /// <summary>
    /// Gets an airport by id
    /// </summary>
    /// <param name="id">Airport identifier</param>
    /// <returns>An airport with a status code</returns>
    [HttpGet("{id}", Name = "GetAirport")]
    public async Task<ActionResult<AirportDto>> GetAirport(int id)
    {
        var airportResult = await _airportService.GetByPkAsync(id);

        if (!airportResult.Success)
            return StatusCode(airportResult.StatusCode, airportResult.Message);

        return Ok(airportResult.Data);
    }

    /// <summary>
    /// Creates a new airport
    /// </summary>
    /// <param name="createAirportDto">DTO for creating a new airport</param>
    /// <returns>Status code with message</returns>
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

    /// <summary>
    /// Updates an airport by id
    /// </summary>
    /// <param name="id">Airport identifier</param>
    /// <param name="updateAirportDto">DTO for updating an airport</param>
    /// <returns>Status code with message</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAirport(int id, UpdateAirportDto updateAirportDto)
    {
        var result = await _airportService.UpdateAsync(id, updateAirportDto);

        return StatusCode(result.StatusCode, result.Message);
    }

    /// <summary>
    /// Partially updates an airport by id
    /// </summary>
    /// <param name="id">Airport identifier</param>
    /// <param name="jsonPatchDocument">JSON patch document</param>
    /// <returns>Status code with message</returns>
    [HttpPatch("{id}")]
    public async Task<IActionResult> PartiallyUpdateAirport(int id, JsonPatchDocument<UpdateAirportDto> jsonPatchDocument)
    {
        var result = await _airportService.PartiallyUpdateAsync(id, jsonPatchDocument);

        return StatusCode(result.StatusCode, result.Message);
    }

    /// <summary>
    /// Deletes an airport by id
    /// </summary>
    /// <param name="id">Airport identifier</param>
    /// <returns>Status code with message</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAirport(int id)
    {
        var result = await _airportService.DeleteAsync(id);

        return StatusCode(result.StatusCode, result.Message);
    }
}