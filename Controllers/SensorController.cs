using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCity.API.Data;
using SmartCity.API.Models;

namespace SmartCity.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SensorController : ControllerBase
{
    private readonly AppDbContext _context;

    public SensorController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _context.Sensores.ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var sensor = await _context.Sensores.FindAsync(id);
        return sensor == null ? NotFound() : Ok(sensor);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Sensor sensor)
    {
        _context.Sensores.Add(sensor);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = sensor.Id }, sensor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Sensor sensor)
    {
        if (id != sensor.Id) return BadRequest();

        _context.Entry(sensor).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var sensor = await _context.Sensores.FindAsync(id);
        if (sensor == null) return NotFound();

        _context.Sensores.Remove(sensor);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
