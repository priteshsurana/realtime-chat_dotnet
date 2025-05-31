using Microsoft.AspNetCore.Mvc;

namespace MediaService.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthCheck:ControllerBase
{
    [HttpGet("/health")]
    public IActionResult Get()
    {
        var port = HttpContext.Connection.LocalPort;
        return Ok($"Media service is running on port {port}");
    }
}