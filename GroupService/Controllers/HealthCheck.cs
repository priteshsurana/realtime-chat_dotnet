using Microsoft.AspNetCore.Mvc;

namespace GroupService.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthCheck:ControllerBase
{
    [HttpGet("/health")]
    public IActionResult Get()
    {
        var port = HttpContext.Connection.LocalPort;
        return Ok($"Group service is running on port {port}");
    }
}