using EclipseSentinel.API.Data;
using EclipseSentinel.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EclipseSentinel.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AreaController : ControllerBase
{
    private readonly EclipseContext _context;

    public AreaController(EclipseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var areas = await _context.Areas
            .Include(a => a.Sensores)
            .ToListAsync();

        return Ok(areas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        var area = await _context.Areas
            .Include(a => a.Sensores)
            .FirstOrDefaultAsync(a => a.IdArea == id);

        if (area == null)
            return NotFound();

        return Ok(area);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Area area)
    {
        _context.Areas.Add(area);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get),
            new { id = area.IdArea }, area);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, [FromBody] Area area)
    {
        if (id != area.IdArea)
            return BadRequest();

        _context.Entry(area).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var area = await _context.Areas.FindAsync(id);

        if (area == null)
            return NotFound();

        _context.Areas.Remove(area);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}