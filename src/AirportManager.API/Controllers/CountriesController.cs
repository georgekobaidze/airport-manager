using AirportManager.API.Common;
using AirportManager.API.DTOs;
using AirportManager.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AirportManager.API.Controllers;

[Route("api/countries")]
[Authorize]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountriesController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CountryDto>>> GetCountries([FromQuery] PagingOptions pagingOptions)
    {
        var countriesPaginationResult = await _countryService.GetAllAsync(pagingOptions);

        Response.Headers.Append("x-pagination", JsonConvert.SerializeObject(countriesPaginationResult.PaginationMetadata));

        return Ok(countriesPaginationResult.Data);
    }

    [HttpHead]
    public async Task<IActionResult> HeadCountries([FromQuery] PagingOptions pagingOptions)
    {
        var countriesPaginationResult = await _countryService.GetAllAsync(pagingOptions);

        Response.Headers.Append("x-pagination", JsonConvert.SerializeObject(countriesPaginationResult.PaginationMetadata));

        return Ok();
    }

    [HttpGet("{id}", Name = "GetCountry")]
    public async Task<ActionResult<CountryDto>> GetCountry(int id)
    {
        var countryResult = await _countryService.GetByPkAsync(id);

        if (!countryResult.Success)
            return StatusCode(countryResult.StatusCode, countryResult.Message);

        return Ok(countryResult.Data);
    }

    [HttpPost]
    public async Task<ActionResult> CreateCountry(CreateCountryDto country)
    {
        var insertionResult = await _countryService.CreateAsync(country);
        if (insertionResult.Success)
        {
            var countryId = insertionResult.Data;

            return CreatedAtRoute(
                "GetCountry",
                new { id = countryId },
                new CountryDto
                {
                    Id = countryId,
                    Name = country.Name
                });
        }

        return StatusCode(StatusCodes.Status500InternalServerError, insertionResult.Message);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCountry(int id, UpdateCountryDto countryDto)
    {
        var result = await _countryService.UpdateAsync(id, countryDto);

        return StatusCode(result.StatusCode, result.Message);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PartiallyUpdateCountry(int id, JsonPatchDocument<UpdateCountryDto> jsonPatchDocument)
    {
        var result = await _countryService.PartiallyUpdateAsync(id, jsonPatchDocument);

        return StatusCode(result.StatusCode, result.Message);
    }

    /// <summary>
    /// Deletes a country by id
    /// </summary>
    /// <param name="id">Country identifier</param>
    /// <returns>Status code with message</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCountry(int id)
    {
        var result = await _countryService.DeleteAsync(id);

        return StatusCode(result.StatusCode, result.Message);
    }

    [HttpOptions]
    public IActionResult GetCountriesOptions()
    {
        Response.Headers.Append("Allow", "GET,POST,HEAD,OPTIONS");
        return Ok();
    }

    [HttpOptions("{id}")]
    public IActionResult GetCountryOptions()
    {
        // For a single country, allow GET, PUT, PATCH, DELETE, HEAD, OPTIONS
        Response.Headers.Append("Allow", "GET,PUT,PATCH,DELETE,HEAD,OPTIONS");
        return Ok();
    }
}