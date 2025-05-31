using Microsoft.AspNetCore.Mvc;

namespace MessageStorageService.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthCheck:ControllerBase
{
    [HttpGet("/health")]
    public IActionResult Get()
    {
        var port = HttpContext.Connection.LocalPort;
        return Ok($"MessageStorage service is running on port {port}");
    }
}