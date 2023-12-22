using FrogWorld.Models;
using FrogWorld.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrogWorld.Controllers;

[ApiController]
[Route("[controller]")]
public class FrogController : ControllerBase
{
    public FrogController()
    {
    }

    [HttpGet]
    public ActionResult<List<Frog>> GetAll() => FrogService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Frog> Get(int id)
    {
        var frog = FrogService.Get(id);

        if (frog == null)
            return NotFound();

        return frog;
    }

    [HttpPost]
    public IActionResult Create(Frog frog)
    {
        FrogService.Add(frog);
        return CreatedAtAction(nameof(Get), new { id = frog.Id }, frog);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Frog frog)
    {
        if (id != frog.Id)
            return BadRequest();

        var existingFrog = FrogService.Get(id);
        if (existingFrog is null)
            return NotFound();

        FrogService.Update(frog);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var frog = FrogService.Get(id);

        if (frog is null)
            return NotFound();

        FrogService.Delete(id);

        return NoContent();
    }
}