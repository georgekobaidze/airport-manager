using Microsoft.AspNetCore.Mvc;

namespace AirportManager.API.Controllers;

[ApiController]
[Route("api/documents")]
public class DocumentsController : ControllerBase
{
    [HttpGet("{id}")]
    public ActionResult GetDocument(int id)
    {
        var baseDirectory = AppContext.BaseDirectory;
        
        var filePath = Path.Combine(baseDirectory, "..", "..", "..", "..", "..", "docs", "airport-info.txt");

        if (!System.IO.File.Exists(filePath))
            return NotFound();
        
        var bytes = System.IO.File.ReadAllBytes(filePath);
        return File(bytes, "text/plain", "airport-info.txt");
    }
}