using EclipseSentinel.API.Data;
using EclipseSentinel.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EclipseSentinel.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OcorrenciaController : ControllerBase
{
    private readonly EclipseContext _context;

    public OcorrenciaController(EclipseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _context.Ocorrencias
            .Include(o => o.Area)
            .ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        var ocorrencia = await _context.Ocorrencias
            .Include(o => o.Area)
            .FirstOrDefaultAsync(o => o.IdOcorrencia == id);

        if (ocorrencia == null)
            return NotFound();

        return Ok(ocorrencia);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Ocorrencia ocorrencia)
    {
        _context.Ocorrencias.Add(ocorrencia);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = ocorrencia.IdOcorrencia }, ocorrencia);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, [FromBody] Ocorrencia ocorrencia)
    {
        if (id != ocorrencia.IdOcorrencia)
            return BadRequest();

        _context.Entry(ocorrencia).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var ocorrencia = await _context.Ocorrencias.FindAsync(id);

        if (ocorrencia == null)
            return NotFound();

        _context.Ocorrencias.Remove(ocorrencia);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}