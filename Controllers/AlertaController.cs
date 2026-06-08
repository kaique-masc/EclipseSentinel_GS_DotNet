using EclipseSentinel.API.Data;
using EclipseSentinel.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EclipseSentinel.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlertaController : ControllerBase
{
    private readonly EclipseContext _context;

    public AlertaController(EclipseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _context.Alertas
            .Include(a => a.Area)
            .ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        var alerta = await _context.Alertas
            .Include(a => a.Area)
            .FirstOrDefaultAsync(a => a.IdAlerta == id);

        if (alerta == null)
            return NotFound();

        return Ok(alerta);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Alerta alerta)
    {
        _context.Alertas.Add(alerta);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = alerta.IdAlerta }, alerta);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, [FromBody] Alerta alerta)
    {
        if (id != alerta.IdAlerta)
            return BadRequest();

        _context.Entry(alerta).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var alerta = await _context.Alertas.FindAsync(id);

        if (alerta == null)
            return NotFound();

        _context.Alertas.Remove(alerta);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}