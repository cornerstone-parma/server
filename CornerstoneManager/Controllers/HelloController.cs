using CornerstoneManager.Data;
using Microsoft.AspNetCore.Mvc;

namespace CornerstoneManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloController(DataContext context) : ControllerBase
{
    private readonly DataContext _context = context;

    [HttpGet]
    public IActionResult GetPeople()
    {
        var people = context.Persons.ToList();
        
        return Ok(people);
    }
}