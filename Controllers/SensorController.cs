using EclipseSentinel.API.Data;
using EclipseSentinel.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EclipseSentinel.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SensorController : ControllerBase
{
    private readonly EclipseContext _context;

    public SensorController(EclipseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var sensores = await _context.Sensores
            .Include(s => s.Area)
            .ToListAsync();

        return Ok(sensores);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        var sensor = await _context.Sensores
            .Include(s => s.Area)
            .FirstOrDefaultAsync(s => s.IdSensor == id);

        if (sensor == null)
            return NotFound();

        return Ok(sensor);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Sensor sensor)
    {
        _context.Sensores.Add(sensor);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get),
            new { id = sensor.IdSensor }, sensor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, [FromBody] Sensor sensor)
    {
        if (id != sensor.IdSensor)
            return BadRequest();

        _context.Entry(sensor).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var sensor = await _context.Sensores.FindAsync(id);

        if (sensor == null)
            return NotFound();

        _context.Sensores.Remove(sensor);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}