using AirportManager.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AirportManager.API.Controllers;

[Route("api/countries")]
[ApiController]
public class CountriesController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<CountryDto>> GetCountries()
    {
        var countries = DummyDataProvider.GetCountries();

        return Ok(countries);
    }

    [HttpGet("{id}", Name = "GetCountry")]
    public ActionResult<CountryDto> GetCountry(int id)
    {
        var allCountries = DummyDataProvider.GetCountries();
        var country = allCountries.Find(country => country.Id == id);

        if (country == null)
            return NotFound();

        return Ok(country);
    }

    [HttpPost]
    public ActionResult CreateCountry(CreateCountryDto country)
    {
        var test = ModelState;
        var countryId = DummyDataProvider.CreateCountry(country);

        if (countryId != -1)
            return CreatedAtRoute(
                "GetCountry",
                new { id = countryId },
                new CountryDto
                {
                    Id = countryId,
                    Name = country.Name,
                    NumberOfAirports = country.NumberOfAirports
                });

        return StatusCode(StatusCodes.Status500InternalServerError);       
    }
}