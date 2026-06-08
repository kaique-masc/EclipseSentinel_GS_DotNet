using EclipseSentinel.API.Data;
using EclipseSentinel.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EclipseSentinel.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeituraSensorController : ControllerBase
{
    private readonly EclipseContext _context;

    public LeituraSensorController(EclipseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var leituras = await _context.LeiturasSensor
            .Include(l => l.Sensor)
            .ToListAsync();

        return Ok(leituras);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        var leitura = await _context.LeiturasSensor
            .Include(l => l.Sensor)
            .FirstOrDefaultAsync(l => l.IdLeitura == id);

        if (leitura == null)
            return NotFound();

        return Ok(leitura);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] LeituraSensor leitura)
    {
        _context.LeiturasSensor.Add(leitura);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get),
            new { id = leitura.IdLeitura }, leitura);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, [FromBody] LeituraSensor leitura)
    {
        if (id != leitura.IdLeitura)
            return BadRequest();

        _context.Entry(leitura).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var leitura = await _context.LeiturasSensor.FindAsync(id);

        if (leitura == null)
            return NotFound();

        _context.LeiturasSensor.Remove(leitura);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}