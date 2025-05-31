using Microsoft.AspNetCore.Mvc;

namespace ChatServer.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthCheck: ControllerBase
{
    [HttpGet("/health")]
    public IActionResult Get()
    {
        var port = HttpContext.Connection.LocalPort;
        return Ok($"Chat Server is running on port {port}");
    }
}