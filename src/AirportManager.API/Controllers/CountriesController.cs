using Microsoft.AspNetCore.Mvc;

namespace AirportManager.API.Controllers;

[Route("api/countries")]
[ApiController]
public class CountriesController : ControllerBase
{
    [HttpGet]
    public JsonResult GetCountries()
    {
        var countries = DummyDataProvider.Countries.GetCountries();

        return new JsonResult(countries);
    }

    [HttpGet("{id}")]
    public JsonResult GetCountry(int id)
    {
        var allCountries = DummyDataProvider.Countries.GetCountries();
        var country = allCountries.Find(country => country.Id == id);

        return new JsonResult(country);
    }
}