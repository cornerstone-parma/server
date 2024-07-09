using Microsoft.AspNetCore.Mvc;

namespace CornerstoneManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public IActionResult GetGreeting()
    {
        return Ok("Hello World");
    }
}