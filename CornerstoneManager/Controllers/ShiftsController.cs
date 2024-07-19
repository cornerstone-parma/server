using CornerstoneManager.Entities;
using CornerstoneManager.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CornerstoneManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShiftsController(IShiftRepository shiftRepository, IConfiguration config) : ControllerBase
{
    [HttpGet("env")]
    public string GetEnv()
    {
        return config.GetValue<string>("test") ?? "string.Empty";
    }

    [HttpGet]
    public ActionResult<ICollection<Shift>> GetAll()
    {
        return Ok(shiftRepository.GetAll());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Shift> GetById(int id)
    {
        return Ok(shiftRepository.GetById(id));
    }

    [HttpPost]
    public ActionResult<Shift> Create(Shift shift)
    {
        shiftRepository.Add(shift);
        
        return CreatedAtAction(nameof(GetById), new {id = shift.Id}, shift);
    }

    [HttpPut("{id:int}")]
    public ActionResult<Shift> Update(int id, Shift shift)
    {
        if (!shiftRepository.Exists(id)) NotFound("Shift not found, id: " + id);

        shift.Id = id;
        if (shiftRepository.Update(shift) > 0) return Ok(shiftRepository.GetById(id));
 
        return BadRequest("Oops, something went wrong");
    }
    
    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var shift = shiftRepository.GetById(id);
        
        if (shift is not null) shiftRepository.Delete(shift);
        
        return NoContent();
    }
}