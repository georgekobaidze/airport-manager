using AirportManager.API.DTOs;
using AirportManager.API.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AirportManager.API.Controllers;

[Route("api/countries")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountriesController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CountryDto>>> GetCountries()
    {
        var countries = await _countryService.GetAllAsync();

        return Ok(countries);
    }

    [HttpGet("{id}", Name = "GetCountry")]
    public ActionResult<CountryDto> GetCountry(int id)
    {
        var country = _countryService.GetByPkAsync(id);

        if (country == null)
            return NotFound();

        return Ok(country);
    }

    [HttpPost]
    public async Task<ActionResult> CreateCountry(CreateCountryDto country)
    {
        var countryId = await _countryService.CreateAsync(country);

        // if (countryId != -1)
        //     return CreatedAtRoute(
        //         "GetCountry",
        //         new { id = countryId },
        //         new CountryDto
        //         {
        //             Id = countryId,
        //             Name = country.Name,
        //             NumberOfAirports = country.NumberOfAirports
        //         });

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCountry(int id, UpdateCountryDto country)
    {
        await _countryService.UpdateAsync(id, country);

        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PartiallyUpdateCountry(int id, JsonPatchDocument<UpdateCountryDto> jsonPatchDocument)
    {
        // var countryFromStore = DummyDataProvider.GetCountries().FirstOrDefault(x => x.Id == id);
        // if (countryFromStore == null)
        //     return NotFound();

        // var countryToPatch = new UpdateCountryDto
        // {
        //     Name = countryFromStore.Name,
        //     NumberOfAirports = countryFromStore.NumberOfAirports
        // };

        // jsonPatchDocument.ApplyTo(countryToPatch, ModelState);

        // if (!ModelState.IsValid)
        //     return BadRequest(ModelState);

        // if (!TryValidateModel(countryToPatch))
        //     return BadRequest(ModelState);

        // countryFromStore.Name = countryToPatch.Name;
        // countryFromStore.NumberOfAirports = countryToPatch.NumberOfAirports;

        // return NoContent();

        await _countryService.PartiallyUpdateAsync(id, jsonPatchDocument);
        return NoContent();
    }
}