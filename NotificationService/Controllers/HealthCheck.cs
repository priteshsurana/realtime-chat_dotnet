using Microsoft.AspNetCore.Mvc;

namespace NotificationService.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthCheck: ControllerBase
{
    [HttpGet("/health")]
    public IActionResult Get()
    {
        var port = HttpContext.Connection.LocalPort;
        return Ok($"Notification service is running on port {port}");
    }
}