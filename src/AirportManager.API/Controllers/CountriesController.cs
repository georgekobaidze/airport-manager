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

    [HttpGet("{id}")]
    public ActionResult<CountryDto> GetCountry(int id)
    {
        var allCountries = DummyDataProvider.GetCountries();
        var country = allCountries.Find(country => country.Id == id);

        if (country == null)
            return NotFound();

        return Ok(country);
    }
}