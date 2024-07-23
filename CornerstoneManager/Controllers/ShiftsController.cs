using CornerstoneManager.Entities;
using CornerstoneManager.Filter;
using CornerstoneManager.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CornerstoneManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShiftsController(IRepository<Shift> shiftRepository) : ControllerBase
{
    [HttpGet]
    public ActionResult<ICollection<Shift>> GetAll()
    {
        return Ok(shiftRepository.GetAll());
    }

    [HttpGet("{id:int}")]
    [ValidateId<Shift>]
    public ActionResult<Shift> GetById(int id)
    {
        return Ok(shiftRepository.GetById(id));
    }

    [HttpPost]
    [ValidateShiftStartAtEndAt]
    public ActionResult<Shift> Create(Shift shift)
    {
        shift = shiftRepository.Add(shift);

        return CreatedAtAction(nameof(GetById), new { id = shift.Id }, shift);
    }

    [HttpPut("{id:int}")]
    [ValidateId<Shift>]
    [ValidateShiftStartAtEndAt]
    public ActionResult<Shift> Update(int id, Shift shift)
    {
        shift.Id = id;
        if (shiftRepository.Update(shift) > 0)
            return Ok(shiftRepository.GetById(id));

        return BadRequest("Oops, something went wrong");
    }

    [HttpDelete("{id:int}")]
    [ValidateId<Shift>]
    public ActionResult Delete(int id)
    {
        shiftRepository.Delete(id);

        return NoContent();
    }
}