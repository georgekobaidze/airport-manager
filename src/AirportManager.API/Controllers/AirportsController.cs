using AirportManager.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AirportManager.API.Controllers;

[ApiController]
[Route("api/airports")]
public class AirportsController : ControllerBase
{
    [HttpGet]
    public ActionResult<ICollection<AirportDto>> GetAirports()
    {
        return Ok();
    }
}