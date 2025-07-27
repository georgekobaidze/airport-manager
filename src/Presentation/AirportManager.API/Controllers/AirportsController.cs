using AirportManager.API.Common;
using AirportManager.API.Dtos.Airports.Requests;
using AirportManager.API.Dtos.Airports.Responses;
using AirportManager.API.Services.Interfaces;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AirportManager.API.Controllers;

[ApiController]
[Authorize]
[Route("api/v{version:apiVersion}/airports")]
[ApiVersion(1)]
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
    public async Task<ActionResult<ICollection<AirportResponse>>> GetAirports([FromQuery] PagingOptions pagingOptions)
    {
        var airportsPaginatedResult = await _airportService.GetAllAsync(pagingOptions);

        Response.Headers.Append("x-pagination", JsonConvert.SerializeObject(airportsPaginatedResult.PaginationMetadata));

        return Ok(airportsPaginatedResult.Data);
    }

    [HttpHead]
    public async Task<ActionResult<ICollection<AirportResponse>>> HeadAirports([FromQuery] PagingOptions pagingOptions)
    {
        var airportsPaginatedResult = await _airportService.GetAllAsync(pagingOptions);

        Response.Headers.Append("x-pagination", JsonConvert.SerializeObject(airportsPaginatedResult.PaginationMetadata));

        return Ok();
    }

    /// <summary>
    /// Gets an airport by id
    /// </summary>
    /// <param name="id">Airport identifier</param>
    /// <returns>An airport with a status code</returns>
    [HttpGet("{id}", Name = "GetAirport")]
    public async Task<ActionResult<AirportResponse>> GetAirport(int id)
    {
        var airportResult = await _airportService.GetByPkAsync(id);

        if (!airportResult.Success)
            return StatusCode(airportResult.StatusCode, airportResult.Message);

        return Ok(airportResult.Data);
    }

    /// <summary>
    /// Creates a new airport
    /// </summary>
    /// <param name="airport">DTO for creating a new airport</param>
    /// <returns>Status code with message</returns>
    [HttpPost]
    public async Task<ActionResult> CreateAirport(CreateAirportRequest airport)
    {
        var insertionResult = await _airportService.CreateAsync(airport);
        if (insertionResult.Success)
        {
            var airportId = insertionResult.Data;

            return CreatedAtRoute(
                "GetAirport",
                new { id = airportId },
                new AirportResponse
                {
                    Id = airportId,
                    CountryId = airport.CountryId,
                    Name = airport.Name
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
    public async Task<ActionResult> UpdateAirport(int id, UpdateAirportRequest airport)
    {
        var result = await _airportService.UpdateAsync(id, airport);

        return StatusCode(result.StatusCode, result.Message);
    }

    /// <summary>
    /// Partially updates an airport by id
    /// </summary>
    /// <param name="id">Airport identifier</param>
    /// <param name="jsonPatchDocument">JSON patch document</param>
    /// <returns>Status code with message</returns>
    [HttpPatch("{id}")]
    public async Task<IActionResult> PartiallyUpdateAirport(int id, JsonPatchDocument<UpdateAirportRequest> jsonPatchDocument)
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

    [HttpOptions]
    public IActionResult GetAirportsOptions()
    {
        Response.Headers.Append("Allow", "GET,POST,HEAD,OPTIONS");
        return Ok();
    }

    [HttpOptions("{id}")]
    public IActionResult GetAirportOptions()
    {
        Response.Headers.Append("Allow", "GET,PUT,PATCH,DELETE,HEAD,OPTIONS");
        return Ok();
    }
}